namespace SKIT.FlurlHttpClient.ByteDance.MicroApp.Models
{
    /// <summary>
    /// <para>表示 [POST] /apps/v1/capacity/update_simple_qr_bind_status 接口的响应。</para>
    /// </summary>
    public class AppsCapacityUpdateSimpleQrcodeBindStatusV1Response : DouyinMicroAppResponse
    {
        /// <inheritdoc/>
        [Newtonsoft.Json.JsonProperty("err_no")]
        [System.Text.Json.Serialization.JsonPropertyName("err_no")]
        public override long ErrorCode { get; set; }

        /// <inheritdoc/>
        [Newtonsoft.Json.JsonProperty("err_msg")]
        [System.Text.Json.Serialization.JsonPropertyName("err_msg")]
        public override string? ErrorMessage { get; set; }
    }
}
