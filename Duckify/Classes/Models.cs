﻿using SpotifyAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Duckify {
    public class SpotifySearchResult {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Length { get; set; }
        public string Artists { get; set; }

        public SpotifySearchResult() {

        }

        public SpotifySearchResult(FullTrack track) {
            Id = track.Id;
            Name = track.Name;
            if (track.Album.Images.Count > 0) {
                ImageUrl = track.Album.Images[0].Url;
            }
            Length = Helper.ConvertMsToReadable(track.DurationMs);
            Artists = track.Artists.Select(x => x.Name).ConvertToString();
        }
    }

    public class QueueItem {
        public FullTrack Track { get; set; }
        public string AddedBy { get; set; }
        public List<string> LikedBy { get; set; } = new List<string>();
        public int Likes { get; set; }
        public string Length { get; set; }

        public QueueItem(FullTrack track, string addedBy = null) {
            Track = track;
            Length = Helper.ConvertMsToReadable(track.DurationMs);
            addedBy = addedBy ?? "Anon";
            AddedBy = addedBy;
            LikedBy.Add(addedBy);
            Likes = 0;
        }
    }

}


