namespace IMEX.Models
{
    public class ApiResponse<T>
    {
        public int Status { get; set; }
        public string Title { get; set; }
        public bool Succeeded { get; set; }
        public List<T> Data { get; set; }
    }
}