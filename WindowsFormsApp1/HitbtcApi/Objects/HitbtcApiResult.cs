namespace HitbtcApi.Objects
{
    public class HitbtcApiResult<T>
    {
        public bool Status { get; set; }

        public T Data { get; set; }

        public string Message { get; set; }

        public HitbtcApiResult()
        {
            Status = true;
        }
    }
    public class HitbalanceData
    {
        public string currency { get; set; }
        public decimal available { get; set; }
        public decimal reserved { get; set; }
    }
}
