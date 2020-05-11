
using System;
using sc2i.common;
namespace futurocom.snmp.Mib
{
    [Serializable]
    public class ValueRange : I2iSerializable
    {
        private Int64 _start;
        private Int64? _end;

        public ValueRange()
        {
        }

        public ValueRange(Symbol first, Symbol second)
        {
            Int64 value = 0;

            if (first.ToString().StartsWith("'"))
            {
                if (first.ToString().EndsWith("B", true, System.Globalization.CultureInfo.InvariantCulture))
                {
                    // Binary number
                    string num = first.ToString().TrimStart(new char[] { '\'' }).TrimEnd(new char[] { 'b', 'B', '\'' });
                    try
                    {
                        value = Convert.ToInt64(num, 2);
                    }
                    catch (Exception)
                    {
                        first.Validate(true, "invalid sub-typing; error parsing start of range");
                    }
                }
                else if (first.ToString().EndsWith("H", true, System.Globalization.CultureInfo.InvariantCulture))
                {
                    // Hex number
                    string num = first.ToString().TrimStart(new char[] { '\'' }).TrimEnd(new char[] { 'h', 'H', '\'' });
                    try
                    {
                        value = Convert.ToInt64(num, 16);
                    }
                    catch (Exception)
                    {
                        first.Validate(true, "invalid sub-typing; error parsing start of range");
                    }
                }
                else
                {
                    first.Validate(true, "invalid sub-typing; error parsing start of range");
                }
            }
            else
            {
                first.Validate(!Int64.TryParse(first.ToString(), out value), "invalid sub-typing; error parsing start of range");
            }
            _start = value;

            if (second != null)
            {
                if (second.ToString().StartsWith("'"))
                {
                    if (second.ToString().EndsWith("B", true, System.Globalization.CultureInfo.InvariantCulture))
                    {
                        // Binary number
                        string num = second.ToString().TrimStart(new char[] { '\'' }).TrimEnd(new char[] { 'b', 'B', '\'' });
                        try
                        {
                            value = Convert.ToInt64(num, 2);
                        }
                        catch (Exception)
                        {
                            second.Validate(true, "invalid sub-typing; error parsing start of range");
                        }
                    }
                    else if (second.ToString().EndsWith("H", true, System.Globalization.CultureInfo.InvariantCulture))
                    {
                        // Hex number
                        string num = second.ToString().TrimStart(new char[] { '\'' }).TrimEnd(new char[] { 'h', 'H', '\'' });
                        try
                        {
                            value = Convert.ToInt64(num, 16);
                        }
                        catch (Exception)
                        {
                            second.Validate(true, "invalid sub-typing; error parsing start of range");
                        }
                    }
                    else
                    {
                        second.Validate(true, "invalid sub-typing; error parsing start of range");
                    }
                }
                else
                {
                    second.Validate(!Int64.TryParse(second.ToString(), out value), "invalid sub-typing; error parsing start of range");
                }
                _end = value;
                second.Validate(_start >= _end, "illegal sub-typing; end of range must be less than start of range");
            }
        }

        public Int64 Start
        {
            get { return _start; }
        }

        public Int64? End
        {
            get { return _end; }
        }

        internal bool Contains(Int64 p)
        {
            if (_end == null)
            {
                return p == _start;
            }
            else
            {
                return _start <= p && p <= _end;
            }
        }

        //-----------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //-----------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion ( ref nVersion );

            long nVal = _start;
            serializer.TraiteLong ( ref nVal );
            _start = (Int64) nVal;

            bool bVal = _end != null;
            serializer.TraiteBool ( ref bVal );
            if ( bVal )
            {
                if ( _end != null )
                    nVal = (long)_end;
                serializer.TraiteLong ( ref nVal );
                _end = (Int64)nVal;
            }
            else
                _end = null;
            return result;
        }

    }
}
