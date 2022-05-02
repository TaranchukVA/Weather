using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Weather.Data.Models
{
    [Table("History")]
    public class HistoryModel
    {
        public Guid Id { get; set; }
        [Column("city")]
        public string City { get; set; }
        [Column("date")]
        public DateTime Date { get; set; }
        [Column("request")]
        public string Request { get; set; }
        [Column("requesttype")]
        public RequestType RequestType { get; set; }
        [Column("responce")]
        public string Response { get; set; }
        [Column("issuccess")]
        public bool IsSuccess { get; set; }
    }
}
