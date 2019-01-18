using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace IllyaVirych.Core.Models
{
    [Table("TaskInGoogleMap")]
    public class TaskInGoogleMap
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int IdTask { get; set;}
        public double LalitudeGoogleMarker { get; set; } 
        public double LongitudeGoogleMarker { get; set; }

        public TaskInGoogleMap(int id, int idTask, double lalitudeGoogleMarker, double longitudeGoogleMarker)
        {
            Id = id;
            IdTask = idTask;
            LalitudeGoogleMarker = lalitudeGoogleMarker;
            LongitudeGoogleMarker = longitudeGoogleMarker;
        }
        public TaskInGoogleMap()
        {

        }
    }
}
