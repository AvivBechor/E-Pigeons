namespace E_Pigeons
{
    public class TextMessage:BasicMessage, IDstId, ISrcId, IText, IGenerate
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

        public byte[] Generate()
        {
            int syncLen;
            int dstIdLen;
            int srcIdLen;
            int txtLen;
            int i;
            int byteSize;
            int start;
            int pow;

            pow = 1;
            start = 0;
            syncLen = GetSync().Length;
            dstIdLen = GetDstId().ToString().Length;
            srcIdLen = GetSrcId().ToString().Length;
            txtLen = GetText().Length;
            byteSize = syncLen + dstIdLen + srcIdLen + txtLen;
            byte[] byteArr = new byte[byteSize];
            
            for (i = 0; i < syncLen; i++, start++)
            {
                byteArr[start] = (byte)(GetSync()[i] - '0');
            }

            for (i = 0; i < dstIdLen; i++, start++)
            {
                byteArr[start] = (byte)(GetDstId()%10*pow);
                pow *= 10;
            }

            pow = 1;
            
            for (i = 0; i < srcIdLen; i++, start++)
            {
                byteArr[start] = (byte)(GetSrcId()%10*pow);
                pow *= 10;
            }

            for ( i = 0; i < txtLen; i++, start++)
            {
                byteArr[start] = (byte) (GetText()[i]);
            }
            
            return byteArr;

        }
    }
}