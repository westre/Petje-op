using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetjeOp
{
    // TODO uitschrijven >> Yoran
    public class Media
    {
        public String Name { get; }
        public String Url { get; }
        public MediaType Type { get; }

        public Media(String Name, String Url, MediaType Type)
        {
            this.Name = Name;
            this.Url = Url;
            this.Type = Type;
        }

        public enum MediaType
        {
            image,
            video,
            youtube
        }
    }
}
