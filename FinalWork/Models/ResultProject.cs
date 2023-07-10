using Newtonsoft.Json;

namespace FinalWork.Models
{
    public class ResultProject
    {
        [JsonProperty("result")] public Project Result { get; set; }

        protected bool Equals(ResultProject other)
        {
            return Result == other.Result;
        }

        public override bool Equals(object? obj)
        {
            return Equals((ResultProject)obj);
        }

        public override int GetHashCode()
        {
            return Result.GetHashCode();
        }

        public override string ToString()
        {
            return $"Result = {Result}";
        }
    }
}
