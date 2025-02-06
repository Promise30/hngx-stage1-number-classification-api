namespace FunFactAPI.Models
{
    public class SuccessResponse    
    {
        public int number { get; set; }
        public bool is_prime { get; set; }
        public bool is_perfect { get; set; }
        public string[] properties { get; set; }
        public int? digit_sum { get; set; }
        public string fun_fact { get; set; }
    }
}
