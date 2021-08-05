using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MediaTracker.Models {
    public static class Media {

        public static IEnumerable<string> GetValues() {
            yield return "Action";
            yield return "Adventure";
            yield return "Comedy";
            yield return "Crime/Mystery";
            yield return "Fantasy";
            yield return "Historical";
            yield return "Historical Fiction";
            yield return "Horror";
            yield return "Romance";
            yield return "Science Fiction";
            yield return "Thriller";
        }

    }
}
