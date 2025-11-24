namespace Application.Data;

public class DefaultResponse<T> where T : class
{
	public T? Data { get; set; }
	public bool Success { get; set; } = true;
	public string Message { get; set; } = string.Empty;
	public int StatusCode { get; set; } = 200;
	public IEnumerable<object> Errors { get; set; } = Array.Empty<object>();
}
