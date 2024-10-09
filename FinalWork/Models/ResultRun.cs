using Newtonsoft.Json;

namespace FinalWork.Models
{
    public class ResultRun
    {
        [JsonProperty("result")] public Run Result { get; set; }

        protected bool Equals(ResultRun other)
        {
            return Result == other.Result;
        }

        public override bool Equals(object? obj)
        {
            return Equals((ResultRun)obj);
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
