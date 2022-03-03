namespace E_Pigeons
{
    public class TextMessage:BasicMessage, IDstId, ISrcId, IText
    {
        private ushort dstId;
        private ushort srcId;
        private string txt;

        public TextMessage(string _sync, ushort _dstId, ushort _srcId, string _txt)
        {
            this.SetSync(_sync);
            this.SetDstId(_dstId);
            this.SetSrcId(_srcId);
            this.SetText(_txt);
        }

        public override void SetSync(string _sync)
        {
            if (!int.TryParse(_sync, out int num))
            {
                _sync = "0101";
            }
            base.SetSync(_sync);
        }

        public void SetDstId(ushort _dstId)
        {
            this.dstId = _dstId;
        }

        public void SetSrcId(ushort _srcId)
        {
            this.srcId = _srcId;
        }

        public void SetText(string _txt)
        {
            this.txt = _txt;
        }

        public ushort GetDstId() => dstId;

        public ushort GetSrcId() => srcId;

        public string GetText() => txt;
    }
}