using System;

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
            if (!Inputer.CheckIfNumber(_sync))
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

        public override byte[] Generate()
        {
            int syncLen;
            int dstIdLen;
            int srcIdLen;
            int txtLen;
            int pow;
            int digit;
            int i;
            int byteSize;
            int start;
            string _sync;
            int _dstId;
            int _srcId;
            string _txt;
            
            start = 0;
            _sync = GetSync();
            _dstId = GetDstId();
            _srcId = GetSrcId();
            _txt = GetText();
            
            syncLen = _sync.Length;
            dstIdLen = _dstId.ToString().Length;
            srcIdLen = _srcId.ToString().Length;
            txtLen = _txt.Length;
            
            byteSize = syncLen + dstIdLen + srcIdLen + txtLen;
            byte[] byteArr = new byte[byteSize];
            
            for (i = 0; i < syncLen; i++, start++)
            {
                byteArr[start] = (byte)(_sync[i] - '0');
            }

            for (i = 0; i < dstIdLen; i++, start++)
            {
                pow = (int) Math.Pow(10, dstIdLen - (i + 1));
                digit = (_dstId / pow) % 10;
                byteArr[start] = (byte)(digit);
            }

            
            for (i = 0; i < srcIdLen; i++, start++)
            {
                pow = (int) Math.Pow(10, srcIdLen - (i + 1));
                digit = (_srcId / pow) % 10;
                byteArr[start] = (byte)(digit);
            }

            for ( i = 0; i < txtLen; i++, start++)
            {
                byteArr[start] = (byte) (_txt[i]);
            }
            
            return byteArr;

        }
    }
}