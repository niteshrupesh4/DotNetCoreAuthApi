using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Helpers;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class DatingRepository : IDatingRepository
    {
        private readonly DEMOContext _context;
        public DatingRepository(DEMOContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Photo> GetMainPhotoForUser(int userId)
        {
            return await _context.Photo.Where(u => u.UserId == userId).FirstOrDefaultAsync(p => p.IsMain);
        }

        public async Task<Photo> GetPhoto(int id)
        {
            var photo = await _context.Photo.FirstOrDefaultAsync(p => p.PhotoId == id);

            return photo;
        }

        public async Task<ExaltUser> GetUser(int id)
        {
            var user = await _context.ExaltUser.Include(p => p.Photos).FirstOrDefaultAsync(u => u.UserId == id);

            return user;
        }

        public async Task<PagedList<ExaltUser>> GetUsers(UserParams userParams)
        {
            var users = _context.ExaltUser.Include(p => p.Photos).OrderByDescending(u => u.LastActive).AsQueryable();

            users = users.Where(u => u.UserId != userParams.userId);

            users = users.Where(u => u.Gender == userParams.Gender);

            if (userParams.MinAge != 10 || userParams.MinAge != 99)
            {
                var minDob = DateTime.Now.AddYears(-userParams.MaxAge - 1);
                var maxDob = DateTime.Now.AddYears(-userParams.MinAge);

                users = users.Where(u => u.DateOfBirth >= minDob && u.DateOfBirth <= maxDob);
            }

            if (!string.IsNullOrEmpty(userParams.OrderBy))
            {
                switch (userParams.OrderBy)
                {
                    case "created":
                        users = users.OrderByDescending(u => u.Created);
                        break;
                    default:
                        users = users.OrderByDescending(u => u.LastActive);
                        break;
                }
            }

            return await PagedList<ExaltUser>.CreateAsync(users, userParams.PageNumber, userParams.PageSize);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
