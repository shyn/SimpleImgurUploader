namespace SimpleImgurUploader.Models;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

public class ImageData
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("datetime")]
    public long Datetime { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("animated")]
    public bool Animated { get; set; }

    [JsonPropertyName("width")]
    public int Width { get; set; }

    [JsonPropertyName("height")]
    public int Height { get; set; }

    [JsonPropertyName("size")]
    public int Size { get; set; }

    [JsonPropertyName("views")]
    public int Views { get; set; }

    [JsonPropertyName("bandwidth")]
    public int Bandwidth { get; set; }

    [JsonPropertyName("vote")]
    public int? Vote { get; set; }

    [JsonPropertyName("favorite")]
    public bool Favorite { get; set; }

    [JsonPropertyName("nsfw")]
    public bool? Nsfw { get; set; }

    [JsonPropertyName("section")]
    public string? Section { get; set; }

    [JsonPropertyName("account_url")]
    public string? AccountUrl { get; set; }

    [JsonPropertyName("account_id")]
    public int AccountId { get; set; }

    [JsonPropertyName("is_ad")]
    public bool IsAd { get; set; }

    [JsonPropertyName("in_most_viral")]
    public bool InMostViral { get; set; }

    [JsonPropertyName("has_sound")]
    public bool HasSound { get; set; }

    [JsonPropertyName("tags")]
    public List<string> Tags { get; set; }

    [JsonPropertyName("ad_type")]
    public int AdType { get; set; }

    [JsonPropertyName("ad_url")]
    public string AdUrl { get; set; }

    [JsonPropertyName("edited")]
    public string Edited { get; set; }

    [JsonPropertyName("in_gallery")]
    public bool InGallery { get; set; }

    [JsonPropertyName("deletehash")]
    public string Deletehash { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("link")]
    public string Link { get; set; }
}

public class ImageResponse
{
    [JsonPropertyName("data")]
    public ImageData Data { get; set; }

    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("status")]
    public int Status { get; set; }
}