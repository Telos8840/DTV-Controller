//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RCS.DTV.RZC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Game
    {
        public Nullable<int> GameKey { get; set; }
        public Nullable<int> Week { get; set; }
        public Nullable<int> Season { get; set; }
        public string SeasonType { get; set; }
        public string TricodeHome { get; set; }
        public string TricodeAway { get; set; }
        public Nullable<int> ScoreHome { get; set; }
        public Nullable<int> ScoreAway { get; set; }
        public string Quarter { get; set; }
        public string GameClock { get; set; }
        public Nullable<int> FileSequence { get; set; }
        public string GameDate { get; set; }
        public int Id { get; set; }
    }
}
