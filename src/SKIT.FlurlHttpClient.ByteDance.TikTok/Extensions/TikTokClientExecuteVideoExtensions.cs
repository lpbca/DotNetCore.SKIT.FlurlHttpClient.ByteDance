﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;

namespace SKIT.FlurlHttpClient.ByteDance.TikTok
{
    public static class TikTokClientExecuteVideoExtensions
    {
        /// <summary>
        /// <para>异步调用 [POST] /video/upload 接口。</para>
        /// <para>REF: https://open.douyin.com/platform/doc/6848798087398295555 </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.VideoUploadResponse> ExecuteVideoUploadAsync(this TikTokClient client, Models.VideoUploadRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateRequest(request, HttpMethod.Post, "video", "upload")
                .SetQueryParam("open_id", request.OpenId)
                .SetQueryParam("access_token", request.AccessToken);

            if (string.IsNullOrEmpty(request.VideoContentType))
                request.VideoContentType = "video/mp4";

            if (string.IsNullOrEmpty(request.VideoFileName))
                request.VideoFileName = Guid.NewGuid().ToString("N").ToLower() + ".mp4";

            using var fileContent = new ByteArrayContent(request.VideoFileBytes ?? new byte[0]);
            using var httpContent = new MultipartFormDataContent();
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(request.VideoContentType);
            httpContent.Add(fileContent, "video", request.VideoFileName);

            return await client.SendRequestAsync<Models.VideoUploadResponse>(flurlReq, httpContent: httpContent, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// <para>异步调用 [POST] /video/part/init 接口。</para>
        /// <para>REF: https://open.douyin.com/platform/doc/6848798087398393859 </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.VideoPartInitializeResponse> ExecuteVideoPartInitializeAsync(this TikTokClient client, Models.VideoPartInitializeRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateRequest(request, HttpMethod.Post, "video", "part", "init")
                .SetQueryParam("open_id", request.OpenId)
                .SetQueryParam("access_token", request.AccessToken);

            return await client.SendRequestWithJsonAsync<Models.VideoPartInitializeResponse>(flurlReq, data: request, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// <para>异步调用 [POST] /video/part/upload 接口。</para>
        /// <para>REF: https://open.douyin.com/platform/doc/6848798087226460172 </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.VideoPartUploadResponse> ExecuteVideoPartUploadAsync(this TikTokClient client, Models.VideoPartUploadRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateRequest(request, HttpMethod.Post, "video", "part", "upload")
                .SetQueryParam("open_id", request.OpenId)
                .SetQueryParam("access_token", request.AccessToken)
                .SetQueryParam("upload_id", request.UploadId)
                .SetQueryParam("part_number", request.PartNumber);

            if (string.IsNullOrEmpty(request.VideoContentType))
                request.VideoContentType = "video/mp4";

            if (string.IsNullOrEmpty(request.VideoFileName))
                request.VideoFileName = Guid.NewGuid().ToString("N").ToLower() + ".mp4";

            using var fileContent = new ByteArrayContent(request.VideoFileBytes ?? new byte[0]);
            using var httpContent = new MultipartFormDataContent();
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(request.VideoContentType);
            httpContent.Add(fileContent, "video", request.VideoFileName);

            return await client.SendRequestAsync<Models.VideoPartUploadResponse>(flurlReq, httpContent: httpContent, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// <para>异步调用 [POST] /video/part/complete 接口。</para>
        /// <para>REF: https://open.douyin.com/platform/doc/6848798087398361091 </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.VideoPartCompleteResponse> ExecuteVideoPartCompleteAsync(this TikTokClient client, Models.VideoPartCompleteRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateRequest(request, HttpMethod.Post, "video", "part", "complete")
                .SetQueryParam("open_id", request.OpenId)
                .SetQueryParam("access_token", request.AccessToken)
                .SetQueryParam("upload_id", request.UploadId);

            return await client.SendRequestWithJsonAsync<Models.VideoPartCompleteResponse>(flurlReq, data: request, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// <para>异步调用 [POST] /video/create 接口。</para>
        /// <para>REF: https://open.douyin.com/platform/doc/6848798087398328323 </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.VideoCreateResponse> ExecuteVideoCreateAsync(this TikTokClient client, Models.VideoCreateRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateRequest(request, HttpMethod.Post, "video", "create")
                .SetQueryParam("open_id", request.OpenId)
                .SetQueryParam("access_token", request.AccessToken);

            return await client.SendRequestWithJsonAsync<Models.VideoCreateResponse>(flurlReq, data: request, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// <para>异步调用 [POST] /video/delete 接口。</para>
        /// <para>REF: https://open.douyin.com/platform/doc/6848806536383383560 </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.VideoDeleteResponse> ExecuteVideoDeleteAsync(this TikTokClient client, Models.VideoDeleteRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateRequest(request, HttpMethod.Post, "video", "delete")
                .SetQueryParam("open_id", request.OpenId)
                .SetQueryParam("access_token", request.AccessToken);

            return await client.SendRequestWithJsonAsync<Models.VideoDeleteResponse>(flurlReq, data: request, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// <para>异步调用 [GET] /video/list 接口。</para>
        /// <para>REF: https://open.douyin.com/platform/doc/6848806536383318024 </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.VideoListResponse> ExecuteVideoListAsync(this TikTokClient client, Models.VideoListRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateRequest(request, HttpMethod.Get, "video", "list")
                .SetQueryParam("open_id", request.OpenId)
                .SetQueryParam("access_token", request.AccessToken)
                .SetQueryParam("cursor", request.PageCursor)
                .SetQueryParam("count", request.PageSize);

            return await client.SendRequestWithJsonAsync<Models.VideoListResponse>(flurlReq, data: request, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// <para>异步调用 [POST] /video/data 接口。</para>
        /// <para>REF: https://open.douyin.com/platform/doc/6848806544931325965 </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.VideoDataResponse> ExecuteVideoDataAsync(this TikTokClient client, Models.VideoDataRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateRequest(request, HttpMethod.Post, "video", "data")
                .SetQueryParam("open_id", request.OpenId)
                .SetQueryParam("access_token", request.AccessToken);

            return await client.SendRequestWithJsonAsync<Models.VideoDataResponse>(flurlReq, data: request, cancellationToken: cancellationToken);
        }

        #region Toutiao
        /// <summary>
        /// <para>异步调用 [POST] /toutiao/video/upload 接口。</para>
        /// <para>REF: https://open.douyin.com/platform/doc/6848806544893642765 </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.ToutiaoVideoUploadResponse> ExecuteToutiaoVideoUploadAsync(this TikTokClient client, Models.ToutiaoVideoUploadRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateRequest(request, HttpMethod.Post, "toutiao", "video", "upload")
                .SetQueryParam("open_id", request.OpenId)
                .SetQueryParam("access_token", request.AccessToken);

            if (string.IsNullOrEmpty(request.VideoContentType))
                request.VideoContentType = "video/mp4";

            if (string.IsNullOrEmpty(request.VideoFileName))
                request.VideoFileName = Guid.NewGuid().ToString("N").ToLower() + ".mp4";

            using var fileContent = new ByteArrayContent(request.VideoFileBytes ?? new byte[0]);
            using var httpContent = new MultipartFormDataContent();
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(request.VideoContentType);
            httpContent.Add(fileContent, "video", request.VideoFileName);

            return await client.SendRequestAsync<Models.ToutiaoVideoUploadResponse>(flurlReq, httpContent: httpContent, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// <para>异步调用 [POST] /toutiao/video/part/init 接口。</para>
        /// <para>REF: https://open.douyin.com/platform/doc/6851812704169003016 </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.ToutiaoVideoPartInitializeResponse> ExecuteToutiaoVideoPartInitializeAsync(this TikTokClient client, Models.ToutiaoVideoPartInitializeRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateRequest(request, HttpMethod.Post, "toutiao", "video", "part", "init")
                .SetQueryParam("open_id", request.OpenId)
                .SetQueryParam("access_token", request.AccessToken);

            return await client.SendRequestWithJsonAsync<Models.ToutiaoVideoPartInitializeResponse>(flurlReq, data: request, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// <para>异步调用 [POST] /toutiao/video/part/upload 接口。</para>
        /// <para>REF: https://open.douyin.com/platform/doc/6851812705242810375 </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.ToutiaoVideoPartUploadResponse> ExecuteToutiaoVideoPartUploadAsync(this TikTokClient client, Models.ToutiaoVideoPartUploadRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateRequest(request, HttpMethod.Post, "toutiao", "video", "part", "upload")
                .SetQueryParam("open_id", request.OpenId)
                .SetQueryParam("access_token", request.AccessToken)
                .SetQueryParam("upload_id", request.UploadId)
                .SetQueryParam("part_number", request.PartNumber);

            if (string.IsNullOrEmpty(request.VideoContentType))
                request.VideoContentType = "video/mp4";

            if (string.IsNullOrEmpty(request.VideoFileName))
                request.VideoFileName = Guid.NewGuid().ToString("N").ToLower() + ".mp4";

            using var fileContent = new ByteArrayContent(request.VideoFileBytes ?? new byte[0]);
            using var httpContent = new MultipartFormDataContent();
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(request.VideoContentType);
            httpContent.Add(fileContent, "video", request.VideoFileName);

            return await client.SendRequestAsync<Models.ToutiaoVideoPartUploadResponse>(flurlReq, httpContent: httpContent, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// <para>异步调用 [POST] /toutiao/video/part/complete 接口。</para>
        /// <para>REF: https://open.douyin.com/platform/doc/6851812703065917448 </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.ToutiaoVideoPartCompleteResponse> ExecuteToutiaoVideoPartCompleteAsync(this TikTokClient client, Models.ToutiaoVideoPartCompleteRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateRequest(request, HttpMethod.Post, "toutiao", "video", "part", "complete")
                .SetQueryParam("open_id", request.OpenId)
                .SetQueryParam("access_token", request.AccessToken)
                .SetQueryParam("upload_id", request.UploadId);

            return await client.SendRequestWithJsonAsync<Models.ToutiaoVideoPartCompleteResponse>(flurlReq, data: request, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// <para>异步调用 [POST] /toutiao/video/create 接口。</para>
        /// <para>REF: https://open.douyin.com/platform/doc/6848806514870880263 </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.ToutiaoVideoCreateResponse> ExecuteToutiaoVideoCreateAsync(this TikTokClient client, Models.ToutiaoVideoCreateRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateRequest(request, HttpMethod.Post, "toutiao", "video", "create")
                .SetQueryParam("open_id", request.OpenId)
                .SetQueryParam("access_token", request.AccessToken);

            return await client.SendRequestWithJsonAsync<Models.ToutiaoVideoCreateResponse>(flurlReq, data: request, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// <para>异步调用 [GET] /toutiao/video/list 接口。</para>
        /// <para>REF: https://open.douyin.com/platform/doc/6848806536383318024 </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.ToutiaoVideoListResponse> ExecuteToutiaoVideoListAsync(this TikTokClient client, Models.ToutiaoVideoListRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateRequest(request, HttpMethod.Get, "toutiao", "video", "list")
                .SetQueryParam("open_id", request.OpenId)
                .SetQueryParam("access_token", request.AccessToken)
                .SetQueryParam("cursor", request.PageCursor)
                .SetQueryParam("count", request.PageSize);

            return await client.SendRequestWithJsonAsync<Models.ToutiaoVideoListResponse>(flurlReq, data: request, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// <para>异步调用 [POST] /toutiao/video/data 接口。</para>
        /// <para>REF: https://open.douyin.com/platform/doc/6848806544931325965 </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.ToutiaoVideoDataResponse> ExecuteToutiaoVideoDataAsync(this TikTokClient client, Models.ToutiaoVideoDataRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateRequest(request, HttpMethod.Post, "toutiao", "video", "data")
                .SetQueryParam("open_id", request.OpenId)
                .SetQueryParam("access_token", request.AccessToken);

            return await client.SendRequestWithJsonAsync<Models.ToutiaoVideoDataResponse>(flurlReq, data: request, cancellationToken: cancellationToken);
        }
        #endregion

        #region Xigua
        /// <summary>
        /// <para>异步调用 [POST] /xigua/video/upload 接口。</para>
        /// <para>REF: https://open.douyin.com/platform/doc/6848806544893642765 </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.XiguaVideoUploadResponse> ExecuteXiguaVideoUploadAsync(this TikTokClient client, Models.XiguaVideoUploadRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateRequest(request, HttpMethod.Post, "xigua", "video", "upload")
                .SetQueryParam("open_id", request.OpenId)
                .SetQueryParam("access_token", request.AccessToken);

            if (string.IsNullOrEmpty(request.VideoContentType))
                request.VideoContentType = "video/mp4";

            if (string.IsNullOrEmpty(request.VideoFileName))
                request.VideoFileName = Guid.NewGuid().ToString("N").ToLower() + ".mp4";

            using var fileContent = new ByteArrayContent(request.VideoFileBytes ?? new byte[0]);
            using var httpContent = new MultipartFormDataContent();
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(request.VideoContentType);
            httpContent.Add(fileContent, "video", request.VideoFileName);

            return await client.SendRequestAsync<Models.XiguaVideoUploadResponse>(flurlReq, httpContent: httpContent, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// <para>异步调用 [POST] /xigua/video/part/init 接口。</para>
        /// <para>REF: https://open.douyin.com/platform/doc/6851812704169003016 </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.XiguaVideoPartInitializeResponse> ExecuteXiguaVideoPartInitializeAsync(this TikTokClient client, Models.XiguaVideoPartInitializeRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateRequest(request, HttpMethod.Post, "xigua", "video", "part", "init")
                .SetQueryParam("open_id", request.OpenId)
                .SetQueryParam("access_token", request.AccessToken);

            return await client.SendRequestWithJsonAsync<Models.XiguaVideoPartInitializeResponse>(flurlReq, data: request, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// <para>异步调用 [POST] /xigua/video/part/upload 接口。</para>
        /// <para>REF: https://open.douyin.com/platform/doc/6851812705242810375 </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.XiguaVideoPartUploadResponse> ExecuteXiguaVideoPartUploadAsync(this TikTokClient client, Models.XiguaVideoPartUploadRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateRequest(request, HttpMethod.Post, "xigua", "video", "part", "upload")
                .SetQueryParam("open_id", request.OpenId)
                .SetQueryParam("access_token", request.AccessToken)
                .SetQueryParam("upload_id", request.UploadId)
                .SetQueryParam("part_number", request.PartNumber);

            if (string.IsNullOrEmpty(request.VideoContentType))
                request.VideoContentType = "video/mp4";

            if (string.IsNullOrEmpty(request.VideoFileName))
                request.VideoFileName = Guid.NewGuid().ToString("N").ToLower() + ".mp4";

            using var fileContent = new ByteArrayContent(request.VideoFileBytes ?? new byte[0]);
            using var httpContent = new MultipartFormDataContent();
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(request.VideoContentType);
            httpContent.Add(fileContent, "video", request.VideoFileName);

            return await client.SendRequestAsync<Models.XiguaVideoPartUploadResponse>(flurlReq, httpContent: httpContent, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// <para>异步调用 [POST] /xigua/video/part/complete 接口。</para>
        /// <para>REF: https://open.douyin.com/platform/doc/6851812703065917448 </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.XiguaVideoPartCompleteResponse> ExecuteXiguaVideoPartCompleteAsync(this TikTokClient client, Models.XiguaVideoPartCompleteRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateRequest(request, HttpMethod.Post, "xigua", "video", "part", "complete")
                .SetQueryParam("open_id", request.OpenId)
                .SetQueryParam("access_token", request.AccessToken)
                .SetQueryParam("upload_id", request.UploadId);

            return await client.SendRequestWithJsonAsync<Models.XiguaVideoPartCompleteResponse>(flurlReq, data: request, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// <para>异步调用 [POST] /xigua/video/create 接口。</para>
        /// <para>REF: https://open.douyin.com/platform/doc/6848806514870880263 </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.XiguaVideoCreateResponse> ExecuteXiguaVideoCreateAsync(this TikTokClient client, Models.XiguaVideoCreateRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateRequest(request, HttpMethod.Post, "xigua", "video", "create")
                .SetQueryParam("open_id", request.OpenId)
                .SetQueryParam("access_token", request.AccessToken);

            return await client.SendRequestWithJsonAsync<Models.XiguaVideoCreateResponse>(flurlReq, data: request, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// <para>异步调用 [GET] /xigua/video/list 接口。</para>
        /// <para>REF: https://open.douyin.com/platform/doc/6848806536383318024 </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.XiguaVideoListResponse> ExecuteXiguaVideoListAsync(this TikTokClient client, Models.XiguaVideoListRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateRequest(request, HttpMethod.Get, "xigua", "video", "list")
                .SetQueryParam("open_id", request.OpenId)
                .SetQueryParam("access_token", request.AccessToken)
                .SetQueryParam("cursor", request.PageCursor)
                .SetQueryParam("count", request.PageSize);

            return await client.SendRequestWithJsonAsync<Models.XiguaVideoListResponse>(flurlReq, data: request, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// <para>异步调用 [POST] /xigua/video/data 接口。</para>
        /// <para>REF: https://open.douyin.com/platform/doc/6848806544931325965 </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.XiguaVideoDataResponse> ExecuteXiguaVideoDataAsync(this TikTokClient client, Models.XiguaVideoDataRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateRequest(request, HttpMethod.Post, "xigua", "video", "data")
                .SetQueryParam("open_id", request.OpenId)
                .SetQueryParam("access_token", request.AccessToken);

            return await client.SendRequestWithJsonAsync<Models.XiguaVideoDataResponse>(flurlReq, data: request, cancellationToken: cancellationToken);
        }
        #endregion
    }
}