using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;

namespace SKIT.FlurlHttpClient.ByteDance.MicroApp
{
    public static class ByteDanceMicroAppClientExecuteAppsExtensions
    {
        /// <summary>
        /// <para>异步调用 [POST] /apps/v2/token 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/interface-request-credential/get-access-token ]]> <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-game/develop/server/interface-request-credential/get-access-token ]]> <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/interaction/develop/server/interface-request-credential/get-access-token ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsTokenV2Response> ExecuteAppsTokenV2Async(this ByteDanceMicroAppClient client, Models.AppsTokenV2Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            if (request.AppId is null)
                request.AppId = client.Credentials.AppId;

            if (request.AppSecret is null)
                request.AppSecret = client.Credentials.AppSecret;

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "v2", "token");

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsTokenV2Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [POST] /apps/v2/jscode2session 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/log-in/code-2-session ]]> <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-game/develop/server/log-in/code-2-session ]]> <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/interaction/develop/server/log-in/code-2-session ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsJsCode2SessionV2Response> ExecuteAppsJsCode2SessionV2Async(this ByteDanceMicroAppClient client, Models.AppsJsCode2SessionV2Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            if (request.AppId is null)
                request.AppId = client.Credentials.AppId;

            if (request.AppSecret is null)
                request.AppSecret = client.Credentials.AppSecret;

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "v2", "jscode2session");

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsJsCode2SessionV2Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        #region Capacity
        /// <summary>
        /// <para>异步调用 [POST] /apps/v1/capacity/upload_material 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/other/upload-material ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCapacityUploadMaterialV1Response> ExecuteAppsCapacityUploadMaterialV1Async(this ByteDanceMicroAppClient client, Models.AppsCapacityUploadMaterialV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            if (request.MaterialFileName is null)
                request.MaterialFileName = Guid.NewGuid().ToString("N").ToLower() + ".jpg";

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "v1", "capacity", "upload_material");

            using var httpContent = Utilities.FileHttpContentBuilder.Build(fileName: request.MaterialFileName, fileBytes: request.MaterialFileBytes, fileContentType: "image/jpeg", formDataName: "material_file");
            httpContent.Add(new ByteArrayContent(Encoding.UTF8.GetBytes(request.MaterialType.ToString())), "material_type");

            return await client.SendFlurlRequestAsync<Models.AppsCapacityUploadMaterialV1Response>(flurlReq, httpContent: httpContent, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        #region Capacity/AwemeCapacity
        /// <summary>
        /// <para>异步调用 [GET] /apps/v1/capacity/query_aweme_permission_list 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/aweme-capacity/query-aweme-permission-list ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCapacityQueryAwemePermissionListV1Response> ExecuteAppsCapacityQueryAwemePermissionListV1Async(this ByteDanceMicroAppClient client, Models.AppsCapacityQueryAwemePermissionListV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Get, "apps", "v1", "capacity", "query_aweme_permission_list")
                .WithHeader("access-token", request.AccessToken);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCapacityQueryAwemePermissionListV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [POST] /apps/v1/capacity/apply_aweme_permission 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/aweme-capacity/apply-aweme-permission ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCapacityApplyAwemePermissionV1Response> ExecuteAppsCapacityApplyAwemePermissionV1Async(this ByteDanceMicroAppClient client, Models.AppsCapacityApplyAwemePermissionV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "v1", "capacity", "apply_aweme_permission")
                .WithHeader("access-token", request.AccessToken);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCapacityApplyAwemePermissionV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [GET] /apps/v1/capacity/query_scope_quota_detail 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/aweme-capacity/query-scope-quota-detail ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCapacityQueryScopeQuotaDetailV1Response> ExecuteAppsCapacityQueryScopeQuotaDetailV1Async(this ByteDanceMicroAppClient client, Models.AppsCapacityQueryScopeQuotaDetailV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Get, "apps", "v1", "capacity", "query_scope_quota_detail")
                .WithHeader("access-token", request.AccessToken)
                .SetQueryParam("permission_key", request.PermissionKey);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCapacityQueryScopeQuotaDetailV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [POST] /apps/v1/capacity/apply_scope_quota 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/aweme-capacity/apply-scope-quota ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCapacityApplyScopeQuotaV1Response> ExecuteAppsCapacityApplyScopeQuotaV1Async(this ByteDanceMicroAppClient client, Models.AppsCapacityApplyScopeQuotaV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "v1", "capacity", "apply_scope_quota")
                .WithHeader("access-token", request.AccessToken);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCapacityApplyScopeQuotaV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [GET] /apps/v1/capacity/query_aweme_video_keyword_list 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/aweme-capacity/query-aweme-video-keyword ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCapacityQueryAwemeVideoKeywordListV1Response> ExecuteAppsCapacityQueryAwemeVideoKeywordListV1Async(this ByteDanceMicroAppClient client, Models.AppsCapacityQueryAwemeVideoKeywordListV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Get, "apps", "v1", "capacity", "query_aweme_video_keyword_list")
                .WithHeader("access-token", request.AccessToken)
                .SetQueryParam("page_num", request.Page)
                .SetQueryParam("page_size", request.Limit);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCapacityQueryAwemeVideoKeywordListV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [POST] /apps/v1/capacity/add_aweme_video_keyword 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/aweme-capacity/add-aweme-video-keyword ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCapacityAddAwemeVideoKeywordV1Response> ExecuteAppsCapacityAddAwemeVideoKeywordV1Async(this ByteDanceMicroAppClient client, Models.AppsCapacityAddAwemeVideoKeywordV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "v1", "capacity", "add_aweme_video_keyword")
                .WithHeader("access-token", request.AccessToken);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCapacityAddAwemeVideoKeywordV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [POST] /apps/v1/capacity/delete_aweme_video_keyword 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/aweme-capacity/delete-aweme-video-keyword ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCapacityDeleteAwemeVideoKeywordV1Response> ExecuteAppsCapacityDeleteAwemeVideoKeywordV1Async(this ByteDanceMicroAppClient client, Models.AppsCapacityDeleteAwemeVideoKeywordV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "v1", "capacity", "delete_aweme_video_keyword")
                .WithHeader("access-token", request.AccessToken);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCapacityDeleteAwemeVideoKeywordV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
        #endregion

        #region Capacity/Delivery
        /// <summary>
        /// <para>异步调用 [POST] /apps/v1/capacity/add_alias 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/delivery/add-alias ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCapacityAddAliasV1Response> ExecuteAppsCapacityAddAliasV1Async(this ByteDanceMicroAppClient client, Models.AppsCapacityAddAliasV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "v1", "capacity", "add_alias")
                .WithHeader("access-token", request.AccessToken);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCapacityAddAliasV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [GET] /apps/v1/capacity/query_alias_list 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/delivery/query-alias-list ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCapacityQueryAliasListV1Response> ExecuteAppsCapacityQueryAliasListV1Async(this ByteDanceMicroAppClient client, Models.AppsCapacityQueryAliasListV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Get, "apps", "v1", "capacity", "query_alias_list")
                .WithHeader("access-token", request.AccessToken);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCapacityQueryAliasListV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [POST] /apps/v1/capacity/modify_alias 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/delivery/modify-alias ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCapacityModifyAliasV1Response> ExecuteAppsCapacityModifyAliasV1Async(this ByteDanceMicroAppClient client, Models.AppsCapacityModifyAliasV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "v1", "capacity", "modify_alias")
                .WithHeader("access-token", request.AccessToken);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCapacityModifyAliasV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [POST] /apps/v1/capacity/delete_alias 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/delivery/delete-alias ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCapacityDeleteAliasV1Response> ExecuteAppsCapacityDeleteAliasV1Async(this ByteDanceMicroAppClient client, Models.AppsCapacityDeleteAliasV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "v1", "capacity", "delete_alias")
                .WithHeader("access-token", request.AccessToken);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCapacityDeleteAliasV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [POST] /apps/v1/capacity/set_search_tag 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/delivery/set-search-tag ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCapacitySetSearchTagV1Response> ExecuteAppsCapacitySetSearchTagV1Async(this ByteDanceMicroAppClient client, Models.AppsCapacitySetSearchTagV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "v1", "capacity", "set_search_tag")
                .WithHeader("access-token", request.AccessToken);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCapacitySetSearchTagV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [GET] /apps/v1/capacity/query_search_tag_list 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/delivery/query-search-tag-list ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCapacityQuerySearchTagListV1Response> ExecuteAppsCapacityQuerySearchTagListV1Async(this ByteDanceMicroAppClient client, Models.AppsCapacityQuerySearchTagListV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Get, "apps", "v1", "capacity", "query_search_tag_list")
                .WithHeader("access-token", request.AccessToken);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCapacityQuerySearchTagListV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
        #endregion

        #region Capacity/FollowAweme
        /// <summary>
        /// <para>异步调用 [POST] /apps/v1/capacity/bind_aweme_user 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/follow-aweme/bind-aweme-user ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCapacityBindAwemeUserV1Response> ExecuteAppsCapacityBindAwemeUserV1Async(this ByteDanceMicroAppClient client, Models.AppsCapacityBindAwemeUserV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "v1", "capacity", "bind_aweme_user")
                .WithHeader("access-token", request.AccessToken);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCapacityBindAwemeUserV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [POST] /apps/v1/capacity/unbind_aweme_user_bind 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/follow-aweme/unbind-aweme-user ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCapacityUnbindAwemeUserV1Response> ExecuteAppsCapacityUnbindAwemeUserV1Async(this ByteDanceMicroAppClient client, Models.AppsCapacityUnbindAwemeUserV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "v1", "capacity", "unbind_aweme_user_bind")
                .WithHeader("access-token", request.AccessToken);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCapacityUnbindAwemeUserV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [GET] /apps/v1/capacity/get_aweme_user_bind_qrcode 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/follow-aweme/get-aweme-user-bind-qrcode ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCapacityGetAwemeUserBindQrcodeV1Response> ExecuteAppsCapacityGetAwemeUserBindQrcodeV1Async(this ByteDanceMicroAppClient client, Models.AppsCapacityGetAwemeUserBindQrcodeV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Get, "apps", "v1", "capacity", "get_aweme_user_bind_qrcode")
                .WithHeader("access-token", request.AccessToken)
                .SetQueryParam("type", request.BindType);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCapacityGetAwemeUserBindQrcodeV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [GET] /apps/v1/capacity/query_aweme_user_bind_list 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/follow-aweme/query-aweme-user-bind-list ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCapacityQueryAwemeUserBindListV1Response> ExecuteAppsCapacityQueryAwemeUserBindListV1Async(this ByteDanceMicroAppClient client, Models.AppsCapacityQueryAwemeUserBindListV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Get, "apps", "v1", "capacity", "query_aweme_user_bind_list")
                .WithHeader("access-token", request.AccessToken)
                .SetQueryParam("type", request.BindType)
                .SetQueryParam("page_num", request.Page)
                .SetQueryParam("page_size", request.Limit);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCapacityQueryAwemeUserBindListV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        #endregion

        #region Capacity/Mount
        /// <summary>
        /// <para>异步调用 [POST] /apps/v1/capacity/apply_capacity 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/mount/apply-self-mount ]]> <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/mount/apply-live-self-mount ]]> <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/mount/apply-video-talent-mount ]]> <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/mount/capcut-video-template/apply-capacity ]]> <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/page-layout-custom/apply-capacity ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCapacityApplyCapacityV1Response> ExecuteAppsCapacityApplyCapacityV1Async(this ByteDanceMicroAppClient client, Models.AppsCapacityApplyCapacityV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "v1", "capacity", "apply_capacity")
                .WithHeader("access-token", request.AccessToken);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCapacityApplyCapacityV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [GET] /apps/v1/capacity/query_apply_status 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/mount/query-video-self-mount ]]> <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/mount/query-live-self-mount ]]> <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/mount/query-video-talent-mount ]]> <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/mount/capcut-video-template/query-status ]]> <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/page-layout-custom/query-capacity-status ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCapacityQueryApplyStatusV1Response> ExecuteAppsCapacityQueryApplyStatusV1Async(this ByteDanceMicroAppClient client, Models.AppsCapacityQueryApplyStatusV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Get, "apps", "v1", "capacity", "query_apply_status")
                .WithHeader("access-token", request.AccessToken)
                .SetQueryParam("capacity_key", request.CapacityKey);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCapacityQueryApplyStatusV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [POST] /apps/v1/capacity/bind_self_mount_user 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/mount/bind-self-mount-user ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCapacityBindSelfMountUserV1Response> ExecuteAppsCapacityBindSelfMountUserV1Async(this ByteDanceMicroAppClient client, Models.AppsCapacityBindSelfMountUserV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "v1", "capacity", "bind_self_mount_user")
                .WithHeader("access-token", request.AccessToken);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCapacityBindSelfMountUserV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [POST] /apps/v1/capacity/unbind_self_mount_user 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/mount/unbind-self-mount-user ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCapacityUnbindSelfMountUserV1Response> ExecuteAppsCapacityUnbindSelfMountUserV1Async(this ByteDanceMicroAppClient client, Models.AppsCapacityUnbindSelfMountUserV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "v1", "capacity", "unbind_self_mount_user")
                .WithHeader("access-token", request.AccessToken);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCapacityUnbindSelfMountUserV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [GET] /apps/v1/capacity/get_self_mount_bind_qrcode 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/mount/get-self-mount-bind-qrcode ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCapacityGetSelfMountBindQrcodeV1Response> ExecuteAppsCapacityGetSelfMountBindQrcodeV1Async(this ByteDanceMicroAppClient client, Models.AppsCapacityGetSelfMountBindQrcodeV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Get, "apps", "v1", "capacity", "get_self_mount_bind_qrcode")
                .WithHeader("access-token", request.AccessToken)
                .SetQueryParam("capacity_key", request.CapacityKey);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCapacityGetSelfMountBindQrcodeV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [GET] /apps/v1/capacity/query_self_mount_user_list 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/mount/query-self-mount-user-list ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCapacityQuerySelfMountUserListV1Response> ExecuteAppsCapacityQuerySelfMountUserListV1Async(this ByteDanceMicroAppClient client, Models.AppsCapacityQuerySelfMountUserListV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Get, "apps", "v1", "capacity", "query_self_mount_user_list")
                .WithHeader("access-token", request.AccessToken)
                .SetQueryParam("capacity_key", request.CapacityKey)
                .SetQueryParam("page_num", request.Page)
                .SetQueryParam("page_size", request.Limit);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCapacityQuerySelfMountUserListV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        #region Capacity/Mount/Capcut
        /// <summary>
        /// <para>异步调用 [GET] /apps/v1/capacity/query_capcut_info 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/mount/capcut-video-template/query-capcut-info ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCapacityQueryCapcutInfoV1Response> ExecuteAppsCapacityQueryCapcutInfoV1Async(this ByteDanceMicroAppClient client, Models.AppsCapacityQueryCapcutInfoV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Get, "apps", "v1", "capacity", "query_capcut_info")
                .WithHeader("access-token", request.AccessToken);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCapacityQueryCapcutInfoV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [GET] /apps/v1/capacity/query_capcut_template_list 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/mount/capcut-video-template/query-capcut-template-list ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCapacityQueryCapcutTemplateListV1Response> ExecuteAppsCapacityQueryCapcutTemplateListV1Async(this ByteDanceMicroAppClient client, Models.AppsCapacityQueryCapcutTemplateListV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Get, "apps", "v1", "capacity", "query_capcut_template_list")
                .WithHeader("access-token", request.AccessToken)
                .SetQueryParam("page_num", request.Page)
                .SetQueryParam("page_size", request.Limit);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCapacityQueryCapcutTemplateListV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [POST] /apps/v1/capacity/update_capcut_template_status 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/mount/capcut-video-template/update-template-status ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCapacityUpdateCapcutTemplateStatusV1Response> ExecuteAppsCapacityUpdateCapcutTemplateStatusV1Async(this ByteDanceMicroAppClient client, Models.AppsCapacityUpdateCapcutTemplateStatusV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "v1", "capacity", "update_capcut_template_status")
                .WithHeader("access-token", request.AccessToken);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCapacityUpdateCapcutTemplateStatusV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
        #endregion
        #endregion

        #region Capacity/SimpleQrcode
        /// <summary>
        /// <para>异步调用 [GET] /apps/v1/capacity/query_simple_qr_bind_list 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/simple-qr-code/query-simple-qr-bind-list ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCapacityQuerySimpleQrcodeBindListV1Response> ExecuteAppsCapacityQuerySimpleQrcodeBindListV1Async(this ByteDanceMicroAppClient client, Models.AppsCapacityQuerySimpleQrcodeBindListV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Get, "apps", "v1", "capacity", "query_simple_qr_bind_list")
                .WithHeader("access-token", request.AccessToken)
                .SetQueryParam("page_num", request.Page)
                .SetQueryParam("page_size", request.Limit);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCapacityQuerySimpleQrcodeBindListV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [POST] /apps/v1/capacity/add_simple_qr_bind 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/simple-qr-code/add-simple-qr-bind ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCapacityAddSimpleQrcodeBindV1Response> ExecuteAppsCapacityAddSimpleQrcodeBindV1Async(this ByteDanceMicroAppClient client, Models.AppsCapacityAddSimpleQrcodeBindV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "v1", "capacity", "add_simple_qr_bind")
                .WithHeader("access-token", request.AccessToken);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCapacityAddSimpleQrcodeBindV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [POST] /apps/v1/capacity/update_simple_qr_bind 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/simple-qr-code/update-simple-qr-bind ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCapacityUpdateSimpleQrcodeBindV1Response> ExecuteAppsCapacityUpdateSimpleQrcodeBindV1Async(this ByteDanceMicroAppClient client, Models.AppsCapacityUpdateSimpleQrcodeBindV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "v1", "capacity", "update_simple_qr_bind")
                .WithHeader("access-token", request.AccessToken);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCapacityUpdateSimpleQrcodeBindV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [POST] /apps/v1/capacity/update_simple_qr_bind_status 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/simple-qr-code/update-simple-qr-bind-status ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCapacityUpdateSimpleQrcodeBindStatusV1Response> ExecuteAppsCapacityUpdateSimpleQrcodeBindStatusV1Async(this ByteDanceMicroAppClient client, Models.AppsCapacityUpdateSimpleQrcodeBindStatusV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "v1", "capacity", "update_simple_qr_bind_status")
                .WithHeader("access-token", request.AccessToken);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCapacityUpdateSimpleQrcodeBindStatusV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [POST] /apps/v1/capacity/delete_simple_qr_bind 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/simple-qr-code/delete-simple-qr-bind ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCapacityDeleteSimpleQrcodeBindV1Response> ExecuteAppsCapacityDeleteSimpleQrcodeBindV1Async(this ByteDanceMicroAppClient client, Models.AppsCapacityDeleteSimpleQrcodeBindV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "v1", "capacity", "delete_simple_qr_bind")
                .WithHeader("access-token", request.AccessToken);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCapacityDeleteSimpleQrcodeBindV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
        #endregion

        #region Capacity/SubscribeNotification
        /// <summary>
        /// <para>异步调用 [GET] /apps/v1/capacity/query_subscribe_notification_tpl_list 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/subscribe-notification/query-template-list ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCapacityQuerySubscribeNotificationTemplateListV1Response> ExecuteAppsCapacityQuerySubscribeNotificationTemplateListV1Async(this ByteDanceMicroAppClient client, Models.AppsCapacityQuerySubscribeNotificationTemplateListV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Get, "apps", "v1", "capacity", "query_subscribe_notification_tpl_list")
                .WithHeader("access-token", request.AccessToken)
                .SetQueryParam("page_num", request.Page)
                .SetQueryParam("page_size", request.Limit)
                .SetQueryParam("classification", request.Classification)
                .SetQueryParam("template_type", request.TemplateType);

            if (request.CategoryIdList is not null)
                flurlReq.SetQueryParam("category_ids", string.Join(",", request.CategoryIdList));

            if (request.Keyword is not null)
                flurlReq.SetQueryParam("keyword", request.Keyword);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCapacityQuerySubscribeNotificationTemplateListV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [GET] /apps/v1/capacity/query_app_subscribe_notification_tpl 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/subscribe-notification/query-app-template-list ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCapacityQueryAppSubscribeNotificationTemplateV1Response> ExecuteAppsCapacityQueryAppSubscribeNotificationTemplateV1Async(this ByteDanceMicroAppClient client, Models.AppsCapacityQueryAppSubscribeNotificationTemplateV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Get, "apps", "v1", "capacity", "query_app_subscribe_notification_tpl")
                .WithHeader("access-token", request.AccessToken)
                .SetQueryParam("page_num", request.Page)
                .SetQueryParam("page_size", request.Limit)
                .SetQueryParam("classification", request.Classification);

            if (request.CategoryIdList is not null)
                flurlReq.SetQueryParam("category_ids", string.Join(",", request.CategoryIdList));

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCapacityQueryAppSubscribeNotificationTemplateV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [GET] /apps/v1/capacity/query_created_subscribe_notification_tpl_list 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/subscribe-notification/query-created-template-list ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCapacityQueryCreatedSubscribeNotificationTemplateListV1Response> ExecuteAppsCapacityQueryCreatedSubscribeNotificationTemplateListV1Async(this ByteDanceMicroAppClient client, Models.AppsCapacityQueryCreatedSubscribeNotificationTemplateListV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Get, "apps", "v1", "capacity", "query_created_subscribe_notification_tpl_list")
                .WithHeader("access-token", request.AccessToken)
                .SetQueryParam("page_num", request.Page)
                .SetQueryParam("page_size", request.Limit);

            if (request.Status is not null)
                flurlReq.SetQueryParam("status", request.Status);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCapacityQueryCreatedSubscribeNotificationTemplateListV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [POST] /apps/v1/capacity/add_app_subscribe_notification_tpl 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/subscribe-notification/add-template ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCapacityAddAppSubscribeNotificationTemplateV1Response> ExecuteAppsCapacityAddAppSubscribeNotificationTemplateV1Async(this ByteDanceMicroAppClient client, Models.AppsCapacityAddAppSubscribeNotificationTemplateV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "v1", "capacity", "add_app_subscribe_notification_tpl")
                .WithHeader("access-token", request.AccessToken);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCapacityAddAppSubscribeNotificationTemplateV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [POST] /apps/v1/capacity/modify_app_subscribe_notification_tpl 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/subscribe-notification/modify-app-template ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCapacityModifyAppSubscribeNotificationTemplateV1Response> ExecuteAppsCapacityModifyAppSubscribeNotificationTemplateV1Async(this ByteDanceMicroAppClient client, Models.AppsCapacityModifyAppSubscribeNotificationTemplateV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "v1", "capacity", "modify_app_subscribe_notification_tpl")
                .WithHeader("access-token", request.AccessToken);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCapacityModifyAppSubscribeNotificationTemplateV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [POST] /apps/v1/capacity/delete_app_subscribe_notification_tpl 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/subscribe-notification/delete-template ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCapacityDeleteAppSubscribeNotificationTemplateV1Response> ExecuteAppsCapacityDeleteAppSubscribeNotificationTemplateV1Async(this ByteDanceMicroAppClient client, Models.AppsCapacityDeleteAppSubscribeNotificationTemplateV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "v1", "capacity", "delete_app_subscribe_notification_tpl")
                .WithHeader("access-token", request.AccessToken);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCapacityDeleteAppSubscribeNotificationTemplateV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [POST] /apps/v1/capacity/create_subscribe_notification_tpl 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/subscribe-notification/create-template ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCapacityCreateAppSubscribeNotificationTemplateV1Response> ExecuteAppsCapacityCreateAppSubscribeNotificationTemplateV1Async(this ByteDanceMicroAppClient client, Models.AppsCapacityCreateAppSubscribeNotificationTemplateV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "v1", "capacity", "create_subscribe_notification_tpl")
                .WithHeader("access-token", request.AccessToken);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCapacityCreateAppSubscribeNotificationTemplateV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
        #endregion

        #region TrafficPermission
        /// <summary>
        /// <para>异步调用 [GET] /apps/v1/capacity/query_traffic_permission_status 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/traffic-permission/query-status ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCapacityQueryTrafficPermissionStatusV1Response> ExecuteAppsCapacityQueryTrafficPermissionStatusV1Async(this ByteDanceMicroAppClient client, Models.AppsCapacityQueryTrafficPermissionStatusV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Get, "apps", "v1", "capacity", "query_traffic_permission_status")
                .WithHeader("access-token", request.AccessToken);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCapacityQueryTrafficPermissionStatusV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [POST] /apps/v1/capacity/open_traffic_permission 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/traffic-permission/open-traffic-permission ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCapacityOpenTrafficPermissionV1Response> ExecuteAppsCapacityOpenTrafficPermissionV1Async(this ByteDanceMicroAppClient client, Models.AppsCapacityOpenTrafficPermissionV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "v1", "capacity", "open_traffic_permission")
                .WithHeader("access-token", request.AccessToken);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCapacityOpenTrafficPermissionV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [GET] /apps/v1/capacity/query_ad_placement_list 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/traffic-permission/query-ad-placement-list ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCapacityQueryAdPlacementListV1Response> ExecuteAppsCapacityQueryAdPlacementListV1Async(this ByteDanceMicroAppClient client, Models.AppsCapacityQueryAdPlacementListV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Get, "apps", "v1", "capacity", "query_ad_placement_list")
                .WithHeader("access-token", request.AccessToken);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCapacityQueryAdPlacementListV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [POST] /apps/v1/capacity/add_ad_placement 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/traffic-permission/add-ad-placement ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCapacityAddAdPlacementV1Response> ExecuteAppsCapacityAddAdPlacementV1Async(this ByteDanceMicroAppClient client, Models.AppsCapacityAddAdPlacementV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "v1", "capacity", "add_ad_placement")
                .WithHeader("access-token", request.AccessToken);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCapacityAddAdPlacementV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [POST] /apps/v1/capacity/update_ad_placement_status 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/traffic-permission/update-ad-placement-status ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCapacityUpdateAdPlacementStatusV1Response> ExecuteAppsCapacityUpdateAdPlacementStatusV1Async(this ByteDanceMicroAppClient client, Models.AppsCapacityUpdateAdPlacementStatusV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "v1", "capacity", "update_ad_placement_status")
                .WithHeader("access-token", request.AccessToken);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCapacityUpdateAdPlacementStatusV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [GET] /apps/v1/capacity/query_ad_income 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/traffic-permission/query-ad-income ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCapacityQueryAdIncomeV1Response> ExecuteAppsCapacityQueryAdIncomeV1Async(this ByteDanceMicroAppClient client, Models.AppsCapacityQueryAdIncomeV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Get, "apps", "v1", "capacity", "query_ad_income")
                .WithHeader("access-token", request.AccessToken)
                .SetQueryParam("start_date", request.StartDateString)
                .SetQueryParam("end_date", request.EndDateString);

            if (request.HostName is not null)
                flurlReq.SetQueryParam("host_name", request.HostName);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCapacityQueryAdIncomeV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [GET] /apps/v1/capacity/query_ad_settlement_list 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/traffic-permission/query-ad-settlement-list ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCapacityQueryAdSettlementListV1Response> ExecuteAppsCapacityQueryAdSettlementListV1Async(this ByteDanceMicroAppClient client, Models.AppsCapacityQueryAdSettlementListV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Get, "apps", "v1", "capacity", "query_ad_settlement_list")
                .WithHeader("access-token", request.AccessToken);

            if (request.PeriodString is not null)
                flurlReq.SetQueryParam("month", request.PeriodString);

            if (request.Status is not null)
                flurlReq.SetQueryParam("status", request.Status);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCapacityQueryAdSettlementListV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
        #endregion
        #endregion

        #region Category
        /// <summary>
        /// <para>异步调用 [GET] /apps/v1/category/query_app_categories 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/category/query-app-categories ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCategoryQueryAppCategoriesV1Response> ExecuteAppsCategoryQueryAppCategoriesV1Async(this ByteDanceMicroAppClient client, Models.AppsCategoryQueryAppCategoriesV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Get, "apps", "v1", "category", "query_app_categories")
                .WithHeader("access-token", request.AccessToken);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCategoryQueryAppCategoriesV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
        #endregion

        #region Censor
        /// <summary>
        /// <para>异步调用 [POST] /apps/censor/image 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/content-security/picture-detect-v2 ]]> <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/thirdparty/API/smallprogram/auth-app-manage/develop/picture-detect ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCensorImageResponse> ExecuteAppsCensorImageAsync(this ByteDanceMicroAppClient client, Models.AppsCensorImageRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            if (request.AppId is null)
                request.AppId = client.Credentials.AppId;

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "censor", "image");
            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCensorImageResponse>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
        #endregion

        #region Chat
        /// <summary>
        /// <para>异步调用 [GET] /apps/chat/customer_service_url 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/im/customer-service-url ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsChatCustomerServiceUrlResponse> ExecuteAppsChatCustomerServiceUrlAsync(this ByteDanceMicroAppClient client, Models.AppsChatCustomerServiceUrlRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            if (request.AppId is null)
                request.AppId = client.Credentials.AppId;

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Get, "apps", "chat", "customer_service_url")
                .WithHeader("access-token", request.AccessToken)
                .SetQueryParam("appid", request.AppId)
                .SetQueryParam("openid", request.OpenId)
                .SetQueryParam("type", request.Type)
                .SetQueryParam("scene", request.Scene);

            if (request.OrderId is not null)
                flurlReq.SetQueryParam("order_id", request.OrderId);

            if (request.IMType is not null)
                flurlReq.SetQueryParam("im_type", request.IMType);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsChatCustomerServiceUrlResponse>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
        #endregion

        #region CustomerService
        /// <summary>
        /// <para>异步调用 [GET] /apps/customer_service/url 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/thirdparty/API/smallprogram/auth-app-manage/operation/microapp/customer-service ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsCustomerServiceUrlResponse> ExecuteAppsCustomerServiceUrlAsync(this ByteDanceMicroAppClient client, Models.AppsCustomerServiceUrlRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            if (request.AppId is null)
                request.AppId = client.Credentials.AppId;

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Get, "apps", "customer_service", "url")
                .SetQueryParam("access_token", request.AccessToken)
                .SetQueryParam("appid", request.AppId)
                .SetQueryParam("openid", request.OpenId)
                .SetQueryParam("type", request.Type)
                .SetQueryParam("scene", request.Scene);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsCustomerServiceUrlResponse>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
        #endregion

        #region DataAnalysis
        #region DataAnalysis/TransactionAnalysis
        /// <summary>
        /// <para>异步调用 [GET] /apps/v1/data_analysis/query_deal_overview_data 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/data-analysis/transaction-analysis/overview-analysis ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsDataAnalysisQueryDealOverviewDataV1Response> ExecuteAppsDataAnalysisQueryDealOverviewDataV1Async(this ByteDanceMicroAppClient client, Models.AppsDataAnalysisQueryDealOverviewDataV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Get, "apps", "v1", "data_analysis", "query_deal_overview_data")
                .WithHeader("access-token", request.AccessToken)
                .SetQueryParam("start_time", request.StartTimestamp)
                .SetQueryParam("end_time", request.EndTimestamp);

            if (request.HostName is not null)
                flurlReq.SetQueryParam("host_name", request.HostName);

            if (request.VersionType is not null)
                flurlReq.SetQueryParam("version_type", request.VersionType);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsDataAnalysisQueryDealOverviewDataV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [GET] /apps/v1/data_analysis/query_video_deal_data 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/data-analysis/transaction-analysis/video-analysis ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsDataAnalysisQueryVideoDealDataV1Response> ExecuteAppsDataAnalysisQueryVideoDealDataV1Async(this ByteDanceMicroAppClient client, Models.AppsDataAnalysisQueryVideoDealDataV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Get, "apps", "v1", "data_analysis", "query_video_deal_data")
                .WithHeader("access-token", request.AccessToken)
                .SetQueryParam("start_time", request.StartTimestamp)
                .SetQueryParam("end_time", request.EndTimestamp);

            if (request.HostName is not null)
                flurlReq.SetQueryParam("host_name", request.HostName);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsDataAnalysisQueryVideoDealDataV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [GET] /apps/v1/data_analysis/query_live_room 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/data-analysis/transaction-analysis/query-live-room ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsDataAnalysisQueryLiveRoomV1Response> ExecuteAppsDataAnalysisQueryLiveRoomV1Async(this ByteDanceMicroAppClient client, Models.AppsDataAnalysisQueryLiveRoomV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Get, "apps", "v1", "data_analysis", "query_live_room")
                .WithHeader("access-token", request.AccessToken);

            if (request.AnchorName is not null)
                flurlReq.SetQueryParam("anchor_name", request.AnchorName);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsDataAnalysisQueryLiveRoomV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [GET] /apps/v1/data_analysis/query_live_room_data 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/data-analysis/transaction-analysis/live-room-data-analysis ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsDataAnalysisQueryLiveRoomDataV1Response> ExecuteAppsDataAnalysisQueryLiveRoomDataV1Async(this ByteDanceMicroAppClient client, Models.AppsDataAnalysisQueryLiveRoomDataV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Get, "apps", "v1", "data_analysis", "query_live_room_data")
                .WithHeader("access-token", request.AccessToken)
                .SetQueryParam("live_room_id", request.LiveRoomId);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsDataAnalysisQueryLiveRoomDataV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [GET] /apps/v1/data_analysis/query_live_deal_data 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/data-analysis/transaction-analysis/live-deal-analysis ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsDataAnalysisQueryLiveDealDataV1Response> ExecuteAppsDataAnalysisQueryLiveDealDataV1Async(this ByteDanceMicroAppClient client, Models.AppsDataAnalysisQueryLiveDealDataV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Get, "apps", "v1", "data_analysis", "query_live_deal_data")
                .WithHeader("access-token", request.AccessToken)
                .SetQueryParam("live_room_id", request.LiveRoomId);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsDataAnalysisQueryLiveDealDataV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [GET] /apps/v1/data_analysis/query_product_deal_data 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/data-analysis/transaction-analysis/product-deal-analysis ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsDataAnalysisQueryProductDealDataV1Response> ExecuteAppsDataAnalysisQueryProductDealDataV1Async(this ByteDanceMicroAppClient client, Models.AppsDataAnalysisQueryProductDealDataV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Get, "apps", "v1", "data_analysis", "query_product_deal_data")
                .WithHeader("access-token", request.AccessToken)
                .SetQueryParam("start_time", request.StartTimestamp)
                .SetQueryParam("end_time", request.EndTimestamp)
                .SetQueryParam("page_num", request.Page)
                .SetQueryParam("page_size", request.Limit);

            if (request.HostName is not null)
                flurlReq.SetQueryParam("host_name", request.HostName);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsDataAnalysisQueryProductDealDataV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
        #endregion

        #region DataAnalysis/UserAnalysis
        /// <summary>
        /// <para>异步调用 [GET] /apps/v1/data_analysis/query_behavior_data 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/data-analysis/user-analysis/behavior-analysis ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsDataAnalysisQueryBehaviorDataV1Response> ExecuteAppsDataAnalysisQueryBehaviorDataV1Async(this ByteDanceMicroAppClient client, Models.AppsDataAnalysisQueryBehaviorDataV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Get, "apps", "v1", "data_analysis", "query_behavior_data")
                .WithHeader("access-token", request.AccessToken)
                .SetQueryParam("start_time", request.StartTimestamp)
                .SetQueryParam("end_time", request.EndTimestamp);

            if (request.HostName is not null)
                flurlReq.SetQueryParam("host_name", request.HostName);

            if (request.OS is not null)
                flurlReq.SetQueryParam("os", request.OS);

            if (request.VersionType is not null)
                flurlReq.SetQueryParam("version_type", request.VersionType);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsDataAnalysisQueryBehaviorDataV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [GET] /apps/v1/data_analysis/query_real_time_user_data 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/data-analysis/user-analysis/realtime-analysis ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsDataAnalysisQueryRealTimeUserDataV1Response> ExecuteAppsDataAnalysisQueryRealTimeUserDataV1Async(this ByteDanceMicroAppClient client, Models.AppsDataAnalysisQueryRealTimeUserDataV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Get, "apps", "v1", "data_analysis", "query_real_time_user_data")
                .WithHeader("access-token", request.AccessToken);

            if (request.HostName is not null)
                flurlReq.SetQueryParam("host_name", request.HostName);

            if (request.VersionType is not null)
                flurlReq.SetQueryParam("version_type", request.VersionType);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsDataAnalysisQueryRealTimeUserDataV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [GET] /apps/v1/data_analysis/query_retention_data 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/data-analysis/user-analysis/retention-analysis ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsDataAnalysisQueryRetentionDataV1Response> ExecuteAppsDataAnalysisQueryRetentionDataV1Async(this ByteDanceMicroAppClient client, Models.AppsDataAnalysisQueryRetentionDataV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Get, "apps", "v1", "data_analysis", "query_retention_data")
                .WithHeader("access-token", request.AccessToken)
                .SetQueryParam("start_time", request.StartTimestamp)
                .SetQueryParam("end_time", request.EndTimestamp);

            if (request.UserType is not null)
                flurlReq.SetQueryParam("user_type", request.UserType);

            if (request.HostName is not null)
                flurlReq.SetQueryParam("host_name", request.HostName);

            if (request.OS is not null)
                flurlReq.SetQueryParam("os", request.OS);

            if (request.VersionType is not null)
                flurlReq.SetQueryParam("version_type", request.VersionType);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsDataAnalysisQueryRetentionDataV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [GET] /apps/v1/data_analysis/query_scene_data 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/data-analysis/user-analysis/scene-analysis ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsDataAnalysisQuerySceneDataV1Response> ExecuteAppsDataAnalysisQuerySceneDataV1Async(this ByteDanceMicroAppClient client, Models.AppsDataAnalysisQuerySceneDataV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Get, "apps", "v1", "data_analysis", "query_scene_data")
                .WithHeader("access-token", request.AccessToken)
                .SetQueryParam("start_time", request.StartTimestamp)
                .SetQueryParam("end_time", request.EndTimestamp);

            if (request.HostName is not null)
                flurlReq.SetQueryParam("host_name", request.HostName);

            if (request.VersionType is not null)
                flurlReq.SetQueryParam("version_type", request.VersionType);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsDataAnalysisQuerySceneDataV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [GET] /apps/v1/data_analysis/query_user_portrait_data 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/data-analysis/user-analysis/user-portrait-analysis ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsDataAnalysisQueryUserPortraitDataV1Response> ExecuteAppsDataAnalysisQueryUserPortraitDataV1Async(this ByteDanceMicroAppClient client, Models.AppsDataAnalysisQueryUserPortraitDataV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Get, "apps", "v1", "data_analysis", "query_user_portrait_data")
                .WithHeader("access-token", request.AccessToken)
                .SetQueryParam("start_time", request.StartTimestamp)
                .SetQueryParam("end_time", request.EndTimestamp);

            if (request.UserType is not null)
                flurlReq.SetQueryParam("user_type", request.UserType);

            if (request.HostName is not null)
                flurlReq.SetQueryParam("host_name", request.HostName);

            if (request.VersionType is not null)
                flurlReq.SetQueryParam("version_type", request.VersionType);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsDataAnalysisQueryUserPortraitDataV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [GET] /apps/v1/data_analysis/query_client_data 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/data-analysis/user-analysis/client-analysis ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsDataAnalysisQueryClientDataV1Response> ExecuteAppsDataAnalysisQueryClientDataV1Async(this ByteDanceMicroAppClient client, Models.AppsDataAnalysisQueryClientDataV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Get, "apps", "v1", "data_analysis", "query_client_data")
                .WithHeader("access-token", request.AccessToken)
                .SetQueryParam("start_time", request.StartTimestamp)
                .SetQueryParam("end_time", request.EndTimestamp);

            if (request.UserType is not null)
                flurlReq.SetQueryParam("user_type", request.UserType);

            if (request.HostName is not null)
                flurlReq.SetQueryParam("host_name", request.HostName);

            if (request.VersionType is not null)
                flurlReq.SetQueryParam("version_type", request.VersionType);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsDataAnalysisQueryClientDataV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [GET] /apps/v1/data_analysis/query_page_data 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/data-analysis/user-analysis/page-analysis ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsDataAnalysisQueryPageDataV1Response> ExecuteAppsDataAnalysisQueryPageDataV1Async(this ByteDanceMicroAppClient client, Models.AppsDataAnalysisQueryPageDataV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Get, "apps", "v1", "data_analysis", "query_page_data")
                .WithHeader("access-token", request.AccessToken)
                .SetQueryParam("start_time", request.StartTimestamp)
                .SetQueryParam("end_time", request.EndTimestamp);

            if (request.HostName is not null)
                flurlReq.SetQueryParam("host_name", request.HostName);

            if (request.OS is not null)
                flurlReq.SetQueryParam("os", request.OS);

            if (request.VersionType is not null)
                flurlReq.SetQueryParam("version_type", request.VersionType);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsDataAnalysisQueryPageDataV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
        #endregion
        #endregion

        #region Live
        /// <summary>
        /// <para>异步调用 [POST] /apps/upload_live_image 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/other/live-bg-image ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsUploadLiveImageResponse> ExecuteAppsUploadLiveImageAsync(this ByteDanceMicroAppClient client, Models.AppsUploadLiveImageRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            if (request.AppId is null)
                request.AppId = client.Credentials.AppId;

            if (request.ImageFileName is null)
                request.ImageFileName = Guid.NewGuid().ToString("N").ToLower() + ".jpg";

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "upload_live_image");

            using var httpContent = Utilities.FileHttpContentBuilder.Build(fileName: request.ImageFileName, fileBytes: request.ImageFileBytes, fileContentType: "image/jpeg", formDataName: "image");
            httpContent.Add(new ByteArrayContent(Encoding.UTF8.GetBytes(request.Title)), "title");
            httpContent.Add(new ByteArrayContent(Encoding.UTF8.GetBytes(request.PagePath)), "start_page");
            if (request.RoomId is not null)
                httpContent.Add(new ByteArrayContent(Encoding.UTF8.GetBytes(request.RoomId.Value.ToString())), "room_id");

            return await client.SendFlurlRequestAsync<Models.AppsUploadLiveImageResponse>(flurlReq, httpContent: httpContent, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [POST] /apps/v1/live/set_black_white_list 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/mount/live-black-white-list ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsLiveSetBlackWhiteListV1Response> ExecuteAppsLiveSetBlackWhiteListV1Async(this ByteDanceMicroAppClient client, Models.AppsLiveSetBlackWhiteListV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            if (request.AppId is null)
                request.AppId = client.Credentials.AppId;

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "v1", "live", "set_black_white_list");

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsLiveSetBlackWhiteListV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
        #endregion

        #region Message
        /// <summary>
        /// <para>异步调用 [POST] /apps/message/custom/send 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/component/message-push-customer-service#%E5%8F%91%E9%80%81%E5%AE%A2%E6%9C%8D%E6%B6%88%E6%81%AF%E6%8E%A5%E5%8F%A3 ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsMessageCustomSendResponse> ExecuteAppsMessageCustomSendAsync(this ByteDanceMicroAppClient client, Models.AppsMessageCustomSendRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "message", "custom", "send")
                .SetQueryParam("access_token", request.AccessToken);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsMessageCustomSendResponse>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
        #endregion

        #region Order
        /// <summary>
        /// <para>异步调用 [POST] /apps/order/v2/push 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/ecpay/order/order-sync ]]> <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/thirdparty/API/smallprogram/auth-app-manage/payment/pushOrder ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsOrderPushV2Response> ExecuteAppsOrderPushV2Async(this ByteDanceMicroAppClient client, Models.AppsOrderPushV2Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "order", "v2", "push")
                .SetQueryParam("access_token", request.AccessToken);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsOrderPushV2Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [POST] /apps/order/delete 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/thirdparty/API/smallprogram/auth-app-manage/payment/deleteOrder ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsOrderDeleteResponse> ExecuteAppsOrderDeleteAsync(this ByteDanceMicroAppClient client, Models.AppsOrderDeleteRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "order", "delete")
                .SetQueryParam("access_token", request.AccessToken);

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsOrderDeleteResponse>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
        #endregion

        #region Qrcode
        /// <summary>
        /// <para>异步调用 [POST] /apps/qrcode 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/qr-code/create-qr-code ]]> <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-game/develop/server/qr-code/create-qr-code ]]> <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/thirdparty/API/smallprogram/auth-app-manage/base-info/getqrcode ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsQrcodeResponse> ExecuteAppsQrcodeAsync(this ByteDanceMicroAppClient client, Models.AppsQrcodeRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "qrcode");

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsQrcodeResponse>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
        #endregion

        #region ShareConfig
        /// <summary>
        /// <para>异步调用 [POST] /apps/share_config 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/mount/ShareConfig ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsShareConfigResponse> ExecuteAppsShareConfigAsync(this ByteDanceMicroAppClient client, Models.AppsShareConfigRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            if (request.AppId is null)
                request.AppId = client.Credentials.AppId;

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "share_config");

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsShareConfigResponse>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
        #endregion

        #region SubscribeNotification
        /// <summary>
        /// <para>异步调用 [POST] /apps/subscribe_notification/developer/v1/notify 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/subscribe-notification/notify ]]> <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-game/develop/server/subscribe-notification/notify ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsSubscribeNotificationDeveloperNotifyV1Response> ExecuteAppsSubscribeNotificationDeveloperNotifyV1Async(this ByteDanceMicroAppClient client, Models.AppsSubscribeNotificationDeveloperNotifyV1Request request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            if (request.AppId is null)
                request.AppId = client.Credentials.AppId;

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "subscribe_notification", "developer", "v1", "notify");

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsSubscribeNotificationDeveloperNotifyV1Response>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
        #endregion

        #region TaskBox
        /// <summary>
        /// <para>异步调用 [POST] /apps/taskbox/add_task 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/promote/taskbox/taskbox-task-upload ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsTaskBoxAddTaskResponse> ExecuteAppsTaskBoxAddTaskAsync(this ByteDanceMicroAppClient client, Models.AppsTaskBoxAddTaskRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            if (request.AppId is null)
                request.AppId = client.Credentials.AppId;

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "taskbox", "add_task");

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsTaskBoxAddTaskResponse>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [POST] /apps/taskbox/update_task 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/promote/taskbox/updatetasks ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsTaskBoxUpdateTaskResponse> ExecuteAppsTaskBoxUpdateTaskAsync(this ByteDanceMicroAppClient client, Models.AppsTaskBoxUpdateTaskRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            if (request.AppId is null)
                request.AppId = client.Credentials.AppId;

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "taskbox", "update_task");

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsTaskBoxUpdateTaskResponse>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [POST] /apps/taskbox/update/status 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/promote/taskbox/updatetaskstatus ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsTaskBoxUpdateStatusResponse> ExecuteAppsTaskBoxUpdateStatusAsync(this ByteDanceMicroAppClient client, Models.AppsTaskBoxUpdateStatusRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            if (request.AppId is null)
                request.AppId = client.Credentials.AppId;

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "taskbox", "update", "status");

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsTaskBoxUpdateStatusResponse>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [POST] /apps/taskbox/query_app_task_id 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/promote/taskbox/taskbox-query-app-task-id ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsTaskBoxQueryAppTaskIdResponse> ExecuteAppsTaskBoxQueryAppTaskIdAsync(this ByteDanceMicroAppClient client, Models.AppsTaskBoxQueryAppTaskIdRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            if (request.AppId is null)
                request.AppId = client.Credentials.AppId;

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "taskbox", "query_app_task_id");

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsTaskBoxQueryAppTaskIdResponse>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [POST] /apps/taskbox/query_task_video_data 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/promote/taskbox/taskbox-query-task-video-data ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsTaskBoxQueryTaskVideoDataResponse> ExecuteAppsTaskBoxQueryTaskVideoDataAsync(this ByteDanceMicroAppClient client, Models.AppsTaskBoxQueryTaskVideoDataRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            if (request.AppId is null)
                request.AppId = client.Credentials.AppId;

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "taskbox", "query_task_video_data");

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsTaskBoxQueryTaskVideoDataResponse>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
        #endregion

        #region UrlLink
        /// <summary>
        /// <para>异步调用 [POST] /apps/url_link/generate 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/share/url-link-generate ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsUrlLinkGenerateResponse> ExecuteAppsUrlLinkGenerateAsync(this ByteDanceMicroAppClient client, Models.AppsUrlLinkGenerateRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            if (request.AppId is null)
                request.AppId = client.Credentials.AppId;

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "url_link", "generate");

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsUrlLinkGenerateResponse>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [POST] /apps/url_link/query_info 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/share/url-link-query ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsUrlLinkQueryInfoResponse> ExecuteAppsUrlLinkQueryInfoAsync(this ByteDanceMicroAppClient client, Models.AppsUrlLinkQueryInfoRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            if (request.AppId is null)
                request.AppId = client.Credentials.AppId;

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "url_link", "query_info");

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsUrlLinkQueryInfoResponse>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [POST] /apps/url_link/query_quota 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/share/url-link-query-quota ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsUrlLinkQueryQuotaResponse> ExecuteAppsUrlLinkQueryQuotaAsync(this ByteDanceMicroAppClient client, Models.AppsUrlLinkQueryQuotaRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            if (request.AppId is null)
                request.AppId = client.Credentials.AppId;

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "url_link", "query_quota");

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsUrlLinkQueryQuotaResponse>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
        #endregion

        #region Video
        /// <summary>
        /// <para>异步调用 [POST] /apps/convert_video_id/video_id_to_open_item_id 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/other/video-id-convert ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsConvertVideoIdToOpenItemIdResponse> ExecuteAppsConvertVideoIdToOpenItemIdAsync(this ByteDanceMicroAppClient client, Models.AppsConvertVideoIdToOpenItemIdRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            if (request.AppId is null)
                request.AppId = client.Credentials.AppId;

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "convert_video_id", "video_id_to_open_item_id");

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsConvertVideoIdToOpenItemIdResponse>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [POST] /apps/convert_video_id/open_item_id_to_encrypt_id 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developer.open-douyin.com/docs/resource/zh-CN/mini-app/develop/server/other/video-id-convert ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.AppsConvertOpenItemIdToEncryptIdResponse> ExecuteAppsConvertOpenItemIdToEncryptIdAsync(this ByteDanceMicroAppClient client, Models.AppsConvertOpenItemIdToEncryptIdRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "apps", "convert_video_id", "open_item_id_to_encrypt_id");

            return await client.SendFlurlRequestAsJsonAsync<Models.AppsConvertOpenItemIdToEncryptIdResponse>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
        #endregion
    }
}
