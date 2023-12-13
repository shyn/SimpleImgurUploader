using System.Net;
using System.Text.Json;
using System.Text.RegularExpressions;
using SimpleImgurUploader.Models;

namespace SimpleImgurUploader;

public class ImgurUploader
{
	const string ImageUploadApiEndpoint = "https://api.imgur.com/3/image";
	const string ImgurUploadPage = "https://imgur.com/upload";
	private const string JsPattern = @"https://s\.imgur\.com/desktop-assets/js/main\.[0-9a-z]+\.js";
	private const string ClientIdPattern = """
	                                       apiClientId: ?"([0-9a-z]+)"
	                                       """;
	private readonly HttpClient _httpClient;
	private string _clientId;

	public ImgurUploader()
	{
		_httpClient = new HttpClient();
	}

	string GetContent(string url)
	{
		var req = new HttpRequestMessage(HttpMethod.Get, url);
		var responseMessage = _httpClient.Send(req);
		responseMessage.EnsureSuccessStatusCode();
		using var reader = new StreamReader(responseMessage.Content.ReadAsStream());
		var body = reader.ReadToEnd();
		return body;
	}
	public string GetAnonymousClientId()
	{
		var body = GetContent(ImgurUploadPage);
		var mainJs = Regex.Match(body, JsPattern).Value;
		var jsContent = GetContent(mainJs);
		var ret = Regex.Match(jsContent, ClientIdPattern).Groups[1].Value;
		return ret;
	}

	public string ClientId
	{
		get
		{
			if (_clientId == null)
			{
				_clientId = GetAnonymousClientId();
			}

			return _clientId;
		}
		set => _clientId = value;
	}

	public string Upload(Stream fileStream)
	{
		var content = new MultipartFormDataContent();
		var fileContent = new StreamContent(fileStream);
		content.Add(fileContent, "image");
		var request = new HttpRequestMessage(HttpMethod.Post, $"{ImageUploadApiEndpoint}?client_id={ClientId}")
		{
			Content = content
		};
		var responseMessage = _httpClient.Send(request);
		responseMessage.EnsureSuccessStatusCode();
		using var reader = responseMessage.Content.ReadAsStream();
		var imageResponse = JsonSerializer.Deserialize<ImageResponse>(reader);
		return imageResponse.Data.Link;
	}

	public string Upload(string filePath)
	{
		using var file = File.OpenRead(filePath);
		return Upload(file);
	}

	public string Upload(byte[] fileContent)
	{
		using var ms = new MemoryStream(fileContent);
		return Upload(ms);
	}
}
