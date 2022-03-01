﻿namespace SKIT.FlurlHttpClient.ByteDance.MicroApp.Models
{
    /// <summary>
    /// <para>表示 [POST] /product/api/upload_resource 接口的响应。</para>
    /// </summary>
    public class ProductApiUploadResourceResponse : ByteDanceMicroAppResponse
    {
        public static class Types
        {
            public class Data
            {
                /// <summary>
                /// 获取或设置资源 URI
                /// </summary>
                [Newtonsoft.Json.JsonProperty("resource_uri")]
                [System.Text.Json.Serialization.JsonPropertyName("resource_uri")]
                public string ResourceUri { get; set; } = default!;
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("err_msg")]
        [System.Text.Json.Serialization.JsonPropertyName("err_msg")]
        public override string? ErrorMessage { get; set; }

        /// <summary>
        /// 获取或设置返回数据
        /// </summary>
        [Newtonsoft.Json.JsonProperty("data")]
        [System.Text.Json.Serialization.JsonPropertyName("data")]
        public Types.Data Data { get; set; } = default!;
    }
}