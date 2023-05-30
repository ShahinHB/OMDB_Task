namespace OMDB_Task.Models
{
    public class MovieListModel
    {
        public List<Movie> Search { get; set; }
        public int TotalResults { get; set; }
        public string Response { get; set; }
        public string Error { get; set; }
    }
}
