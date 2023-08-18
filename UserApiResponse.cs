using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Consume
{
    public class UserApiResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }

    // public class Address
    // {
    //     public string Street { get; set; } = string.Empty;
    //     public string Suite { get; set; } = string.Empty;
    //     public string City { get; set; } = string.Empty;
    //     public string Zipcode { get; set; } = string.Empty;
    //     public Geo Geo { get; set; } = new Geo();
    // }

    // public class Geo
    // {
    //     public string Lat { get; set; } = string.Empty;
    //     public string Lng { get; set; } = string.Empty;
    // }

    public class PostApiResponse
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
    }

    public class CommentApiResponse
    {
        public int PostId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
    }

}