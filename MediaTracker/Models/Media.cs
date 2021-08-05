using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MediaTracker.Models {
    public static class Media {

        public static IEnumerable<string> GetValues() {
            yield return "Action";
            yield return "Comedy";
        }

    }
}
