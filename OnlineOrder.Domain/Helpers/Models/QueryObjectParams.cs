namespace OnlineOrder.Domain.Helpers.Models
{
	/// <summary>
	///
	/// </summary>
	public class QueryObjectParams : PageParam
	{
        /// <summary>
        /// </summary>
        public List<SortParam> SortingParams { get; set; }
    }
}
