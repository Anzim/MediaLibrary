using System;

namespace MediaLibrary.Models
{
    public partial class Track
    {
        public int TrackId { get; set; }
        public string TrackTitle { get; set; }
        public int FolderId { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string TrackYear { get; set; }
        public string Comments { get; set; }
        public string Genre { get; set; }
        public short? TrackNumber { get; set; }
        public string TrackFile { get; set; }
        public string TrackDisplayOption { get; set; }
        public bool Downloadable { get; set; }
        public bool MusicFile { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public string Privacy { get; set; }
        public string FileSize { get; set; }
        public string Duration { get; set; }
        public DateTime AddDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}