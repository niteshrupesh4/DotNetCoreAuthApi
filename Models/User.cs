using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
    }
    public partial class Tbl_User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }

    public partial class Mct_PlanDetail
    {
        [Key]
        public int plan_id { get; set; }
        [Key]
        public int merchant_id { get; set; }
        [Key]
        public int product_id { get; set; }
        public string plan_order_id { get; set; }
        public string plan_name { get; set; }
        public decimal amount { get; set; }
        public int amount_cent { get; set; }
        public string interval { get; set; }
        public int custom_input { get; set; }
        public string custom_interval { get; set; }
        public int quantity { get; set; }
        public string usage_type { get; set; }
        public string aggregate_usage { get; set; }
        public string tiers_mode { get; set; }
        public string billing_scheme { get; set; }
        public string trial_period_day { get; set; }
        public string currency { get; set; }
        public string currency_sign { get; set; }
        public string meta_data { get; set; }
        public bool live_mode { get; set; }
        public bool is_active { get; set; }
        public string created_by { get; set; }
        public DateTime created_date { get; set; }
        public string modified_by { get; set; }
        public DateTime modified_date { get; set; }
    }

}
