namespace disease_tracker_api.Models
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }

        public bool Success { get; set; } = true;

        public string Messsage { get; set; } = null;
        
    }
}