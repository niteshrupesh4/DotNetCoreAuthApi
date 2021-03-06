using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
using DatingApp.API.Helpers;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Authorize]
    [Route("api/users/{userId}/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IDatingRepository _repo;
        private readonly IMapper _mapper;
        public MessagesController(IDatingRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet("{id}", Name = "GetMessage")]
        public async Task<IActionResult> GetMessage(int userId, int id)
        {
                if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                    return Unauthorized();

                var messageForRepo = await _repo.GetMessage(id);

                if (messageForRepo == null)
                    return NotFound();
                
                return Ok(messageForRepo);
        }

        [HttpGet]
        public async Task<IActionResult> GetMessageForuser(int userId,[FromQuery] MessageParams mesasgeParams)
        {
             if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                 return Unauthorized();
            
            mesasgeParams.userId = userId;
            
            var messageForRepo = await _repo.GetMessagesForUser(mesasgeParams);

            var message = _mapper.Map<IEnumerable<MessageToReturnDto>>(messageForRepo);

            Response.AddPagination(messageForRepo.CurrentPage, messageForRepo.PageSize,
                            messageForRepo.TotalCount, messageForRepo.TotalPages);

            return Ok(message);
        }

        [HttpGet("thread/{recipentId}")]
        public async Task<IActionResult> GetMessageThread(int userId, int recipentId)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                 return Unauthorized();
            
            var messageForRepo = await _repo.GetMessageThread(userId, recipentId);

            var messageThread = _mapper.Map<IEnumerable<MessageToReturnDto>>(messageForRepo);

            return Ok(messageThread);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(int userId,
         MessageForCreationDto messageForCreationDto)
         {
            var sender = await _repo.GetUser(userId);

             if (sender.UserId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                 return Unauthorized();
            
            messageForCreationDto.SenderId = userId;

            var recipent = await _repo.GetUser(messageForCreationDto.RecipientId);

            if (recipent == null)
                return BadRequest("Could not find user");
            
            var message = _mapper.Map<Message>(messageForCreationDto);

            _repo.Add(message);           

            if (await _repo.SaveAll())
            {
                var messageToReturnDto = _mapper.Map<MessageToReturnDto>(message);
                return CreatedAtRoute("GetMessage", new { id = message.Id }, messageToReturnDto);
            }                

            throw new Exception("Creating the message failed on save");
         }

         [HttpPost("{id}")]
         public async Task<IActionResult> DeleteMessage(int id, int userId)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var messageFromRepo = await _repo.GetMessage(id);

            if (messageFromRepo.SenderId == userId)
                messageFromRepo.SenderDeleted = true;

            if (messageFromRepo.RecipientId == userId)
                messageFromRepo.RecipientDeleted = true;

            if (messageFromRepo.SenderDeleted && messageFromRepo.RecipientDeleted)
                _repo.Delete(messageFromRepo);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception("Error Deleteing the message");
        }

        [HttpPost("{id}/read")]
        public async Task<IActionResult> MarkMessageRead(int userId, int id)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var message = await _repo.GetMessage(id);

            if (message.RecipientId != userId)
                return Unauthorized();

            message.IsRead = true;
            message.DateRead = DateTime.Now;

            await _repo.SaveAll();

            return NoContent();
        }
    }
}