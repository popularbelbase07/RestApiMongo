﻿using InnovationAPI.DTO;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace InnovationAPI.Models
{
    public class Idea:IdeaDTO
    {
        public Ideator Ideator { get; set; }
        public Segment Segements { get; set; }  
        public List<FeedBack>? Feedbacks { get; set; }    


        public Idea()
        {
            IdeaId = ObjectId.GenerateNewId().ToString();
        }

    }
}
