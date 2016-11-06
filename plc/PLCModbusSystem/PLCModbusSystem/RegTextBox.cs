using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace PLCModbusSystem
{
    class RegTextBox : TextBox
    {
        public enum DataType
        {
            dtShort,
            dtUShort,
            dtHByte,
            dtLByte,
            dtHString,
            dtLString,
            dtFloat,
            dtString,
            dtSingleFloat,
        }

        public enum FloatFMT
        {
            FMT_ABCD,
            FMT_CDAB,
            FMT_BADC,
            FMT_DCBA,
        }

        private ModbusRegisters reg;
        private DataType _dataType;
        private FloatFMT _floatFmt = FloatFMT.FMT_DCBA;
        private int _dtMinValue;
        private int _dtMaxValue;
        private int _dtDivValue = 100;

        public RegTextBox()
        {
            this.Text = "";
            this.dataType = DataType.dtString;
        }

        [CategoryAttribute("寄存器属性"), Browsable(true), DisplayName("Data Min Value"), DescriptionAttribute("最小值")]
        public int dtMinValue
        {
            get { return this._dtMinValue; }
            set {
                if (value <= this._dtMaxValue)
                {
                    this._dtMinValue = value;
                }
            }
        }

        [CategoryAttribute("寄存器属性"), Browsable(true), DisplayName("Data Max Value"), DescriptionAttribute("最大值")]
        public int dtMaxValue
        {
            get { return this._dtMaxValue; }
            set {
                if (value >= this._dtMinValue)
                {
                    this._dtMaxValue = value;
                }
            }
        }

        [CategoryAttribute("寄存器属性"), Browsable(true), DisplayName("Div Value"), DescriptionAttribute("使用浮点数时的除数")]
        public int dtDivValue
        {
            get { return this._dtDivValue; }
            set {
                if (value <= 0)
                {
                    value = 1;
                }
                if (value != 1 && value % 10 != 0)
                {
                    value = 1;
                }
                this._dtDivValue = value; 
            }
        }

        [CategoryAttribute("寄存器属性"), Browsable(true), DisplayName("Data Type"), DescriptionAttribute("数据类型")]
        public DataType dataType
        {
            get { return this._dataType; }
            set {
                this._dataType = value;
            }
        }

        [CategoryAttribute("寄存器属性"), Browsable(true), DisplayName("32bit Float Type"), DescriptionAttribute("浮点数格式")]
        public FloatFMT floatFmt
        {
            get { return this._floatFmt; }
            set
            {
                this._floatFmt = value;
            }
        }
        private int _regIndex;
        [CategoryAttribute("寄存器属性"), Browsable(true), DisplayName("Reg Index"), DescriptionAttribute("寄存器索引")]
        public int RegIndex
        {
            get { return this._regIndex; }
            set
            {
                this._regIndex = value;
            }
        }

        private List<BsItem> items = new List<BsItem>();
        [CategoryAttribute("寄存器属性"), Browsable(true), DisplayName("Reg map"), DescriptionAttribute("寄存器索引")]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Content)]
        public List<BsItem> Items
        {
            set 
            {
                if (value != null)
                {
                    items = value;
                }
            }
            get{return items;}
        }

        protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = true;

            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Enter && e.KeyChar != (char)'-' && e.KeyChar != (char)'.')
            {
                e.Handled = true;
                this.Focus();
                this.SelectAll();
                MessageBox.Show("请输入数字", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Text = "";
            }
            else
            {
                e.Handled = false;
            }

            base.OnKeyPress(e);
        }


        protected override void OnTextChanged(System.EventArgs e)
        {
            int value;
            float fValue;

            switch (this._dataType)
            {
                case DataType.dtString:
                case DataType.dtHString:
                case DataType.dtLString:
                    base.OnTextChanged(e);
                    return;
            }

            if (this.Text == "" || this.Text == "-")
            {
                return;
            }
            else
            {
                if (this._dataType == DataType.dtFloat || this._dataType == DataType.dtSingleFloat)
                {
                    if (!float.TryParse(this.Text, out fValue))
                    {
                        this.Focus();
                        this.SelectAll();
                        MessageBox.Show("请输入正确的浮点数", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Text = "";
                        return;
                    }
                }
                else
                {
                    if (!int.TryParse(this.Text, out value))
                    {
                        this.Focus();
                        this.SelectAll();
                        MessageBox.Show("请输入正确的整数", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Text = "";
                        return;
                    }
                }
            }

            checkAndSaveValue();
            //if (this.Text != "" && this.Text == "-")
            //{
            //    value = int.Parse(this.Text);
            //}
            base.OnTextChanged(e);
        }
        private float getFloatValue()
        {
            float value;
            try
            {
                value = float.Parse(this.Text);
            }
            catch (Exception ex)
            {
                LogClass.GetInstance().WriteExceptionLog(ex);
                this.Text = "";
                value = 0.0f;
            }

            return value;
        }
        private int getIntValue()
        {
            int value;
            try
            {
                if (this._dataType == DataType.dtFloat)
                {
                    value = (int)(float.Parse(this.Text) * this._dtDivValue);
                }
                else
                {
                    value = int.Parse(this.Text);
                }

                getMinMax();

                if (value < this._dtMinValue)
                {
                    this.Text = this._dtMinValue.ToString();
                    value = this._dtMinValue;
                }
                else if (value > this._dtMaxValue)
                {
                    this.Text = this._dtMaxValue.ToString();
                    value = this._dtMaxValue;
                }
            }
            catch (Exception ex)
            {
                LogClass.GetInstance().WriteExceptionLog(ex);
                this.Text = this._dtMinValue.ToString();
                value = this._dtMinValue;
            }

            return value;
        }

        private void checkAndSaveValue()
        {
            int value = 0;
            float fvalue = 0.0f;

            if (reg == null)
            {
                return;
            }

            switch (this._dataType)
            {
                case DataType.dtString:
                case DataType.dtHString:
                case DataType.dtLString:
                    return;
            }

            if (this._dataType != DataType.dtSingleFloat)
            {
                value = getIntValue();
            }
            else
            {
                fvalue = getFloatValue();
            }

            if (this._regIndex > reg.numRegisters)
            {
                throw new ArgumentOutOfRangeException("寄存器读取越界"); 
            }

            switch (this._dataType)
            {
                case DataType.dtShort:
                    reg.stReg[_regIndex].setValue((ushort)short.Parse(value.ToString()));
                    break;
                case DataType.dtUShort:
                    reg.stReg[_regIndex].setValue(ushort.Parse(value.ToString()));
                    break;
                case DataType.dtHByte:
                    reg.stReg[_regIndex].setHighReg(byte.Parse(value.ToString()));
                    break;
                case DataType.dtLByte:
                    reg.stReg[_regIndex].setLowReg(byte.Parse(value.ToString()));
                    break;
                case DataType.dtFloat:
                    reg.stReg[_regIndex].setValue(ushort.Parse(value.ToString()));
                    break;
                case DataType.dtSingleFloat:
                    byte[] bytes = BitConverter.GetBytes(float.Parse(fvalue.ToString()));

                    if (this._floatFmt == FloatFMT.FMT_ABCD)
                    {
                        reg.stReg[_regIndex + 1].setLowReg(bytes[0]);
                        reg.stReg[_regIndex + 1].setHighReg(bytes[1]);
                        reg.stReg[_regIndex].setLowReg(bytes[2]);
                        reg.stReg[_regIndex].setHighReg(bytes[3]);
                    }
                    else if (this._floatFmt == FloatFMT.FMT_CDAB)
                    {
                        reg.stReg[_regIndex].setLowReg(bytes[0]);
                        reg.stReg[_regIndex].setHighReg(bytes[1]);
                        reg.stReg[_regIndex + 1].setLowReg(bytes[2]);
                        reg.stReg[_regIndex + 1].setHighReg(bytes[3]);
                    }
                    else if (this._floatFmt == FloatFMT.FMT_BADC)
                    {
                        reg.stReg[_regIndex + 1].setHighReg(bytes[0]);
                        reg.stReg[_regIndex + 1].setLowReg(bytes[1]);
                        reg.stReg[_regIndex].setHighReg(bytes[2]);
                        reg.stReg[_regIndex].setLowReg(bytes[3]);
                    }
                    else if (this._floatFmt == FloatFMT.FMT_DCBA)
                    {
                        reg.stReg[_regIndex].setHighReg(bytes[0]);
                        reg.stReg[_regIndex].setLowReg(bytes[1]);
                        reg.stReg[_regIndex + 1].setHighReg(bytes[2]);
                        reg.stReg[_regIndex + 1].setLowReg(bytes[3]);
                    }
                    else
                    {
                        return;
                    }


                    break;
                default:
                    break;
            }
            return;
        }

        private void getMinMax()
        {
            switch (this._dataType)
            {
                case DataType.dtShort:
                    if (this.dtMinValue < short.MinValue || this.dtMinValue == 0)
                    {
                        this.dtMinValue = short.MinValue;
                    }

                    if (this.dtMaxValue > short.MaxValue || this.dtMaxValue == 0)
                    {
                        this.dtMaxValue = short.MaxValue;
                    }
                    //this.Text = this.reg.stReg[_regIndex].getShortValue().ToString();
                    break;
                case DataType.dtUShort:
                    if (this.dtMinValue < ushort.MinValue || this.dtMinValue == 0)
                    {
                        this.dtMinValue = ushort.MinValue;
                    }

                    if (this.dtMaxValue > ushort.MaxValue || this.dtMaxValue == 0)
                    {
                        this.dtMaxValue = ushort.MaxValue;
                    }
                    break;
                case DataType.dtHByte:
                case DataType.dtLByte:
                    if (this.dtMinValue < 0 || this.dtMinValue == 0)
                    {
                        this.dtMinValue = 0;
                    }

                    if (this.dtMaxValue > 0xff || this.dtMaxValue == 0)
                    {
                        this.dtMaxValue = 0xff;
                    }
                    break;
                case DataType.dtFloat:
                    if (this.dtMinValue < short.MinValue || this.dtMinValue == 0)
                    {
                        this.dtMinValue = short.MinValue;
                    }

                    if (this.dtMaxValue > short.MaxValue || this.dtMaxValue == 0)
                    {
                        this.dtMaxValue = short.MaxValue;
                    }
                    break;
                case DataType.dtString:
                case DataType.dtHString:
                case DataType.dtLString:
                default:
                    break;
            }
        }

        private void checkMinMax()
        {
            switch (this._dataType)
            {
                case DataType.dtShort:
                    if (this.dtMinValue < short.MinValue)
                    {
                        this.dtMinValue = short.MinValue;
                    }

                    if (this.dtMaxValue > short.MaxValue)
                    {
                        this.dtMaxValue = short.MaxValue;
                    }
                    //this.Text = this.reg.stReg[_regIndex].getShortValue().ToString();
                    break;
                case DataType.dtUShort:
                    if (this.dtMinValue < ushort.MinValue)
                    {
                        this.dtMinValue = ushort.MinValue;
                    }

                    if (this.dtMaxValue > ushort.MaxValue)
                    {
                        this.dtMaxValue = ushort.MaxValue;
                    }
                    break;
                case DataType.dtHByte:
                case DataType.dtLByte:
                    if (this.dtMinValue < 0)
                    {
                        this.dtMinValue = 0;
                    }

                    if (this.dtMaxValue > 0xff)
                    {
                        this.dtMaxValue = 0xff;
                    }
                    break;
                case DataType.dtFloat:
                case DataType.dtString:
                case DataType.dtHString:
                case DataType.dtLString:
                default:
                    break;
            }
        }
         
        public void setReg(ref ModbusRegisters reg)
        {
            this.reg = reg;

            switch (dataType)
            {
                case DataType.dtString:
                case DataType.dtLString:
                case DataType.dtHString:
                    for (int i = 0; i < items.Count; i++)
                    {
                        this.reg.stReg[_regIndex].addStringMap(items[i].index, items[i].mapstring);
                    }
                        
                    break;
                default:
                    break;
            }
            
        }

        public void UpdateData()
        {

            if (this.reg == null)
            {
                return;
            }

            if (this.reg.numRegisters < _regIndex)
            {
                return;
            }

            switch (dataType)
            {
                case DataType.dtShort:
                    this.Text = this.reg.stReg[_regIndex].getShortValue().ToString();
                    break;
                case DataType.dtUShort:
                    this.Text = this.reg.stReg[_regIndex].getUShortValue().ToString();
                    break;
                case DataType.dtHByte:
                    this.Text = this.reg.stReg[_regIndex].getHighReg().ToString();
                    break;
                case DataType.dtLByte:
                    this.Text = this.reg.stReg[_regIndex].getLowReg().ToString();
                    break;
                case DataType.dtFloat:
                    this.Text = this.reg.stReg[_regIndex].getFloatValue(_dtDivValue).ToString();
                    break;
                case DataType.dtString:
                    this.Text = this.reg.stReg[_regIndex].getString();
                    break;
                case DataType.dtLString:
                    this.Text = this.reg.stReg[_regIndex].getLowRegString();
                    break;
                case DataType.dtHString:
                    this.Text = this.reg.stReg[_regIndex].getHighRegString();
                    break;
                case DataType.dtSingleFloat:
                    //this.Text = this.reg.stReg[_regIndex].getFloatValue(_dtDivValue).ToString();
                    byte[] bytes = new byte[4];
                    //bytes[0] = (byte)reg.stReg[_regIndex].getHighReg();
                    //bytes[1] = (byte)reg.stReg[_regIndex].getLowReg();
                    //bytes[2] = (byte)reg.stReg[_regIndex + 1].getHighReg();
                    //bytes[3] = (byte)reg.stReg[_regIndex + 1].getLowReg();
                    if (this._floatFmt == FloatFMT.FMT_ABCD)
                    {
                        bytes[0] = (byte)reg.stReg[_regIndex + 1].getLowReg();
                        bytes[1] = (byte)reg.stReg[_regIndex + 1].getHighReg();
                        bytes[2] = (byte)reg.stReg[_regIndex].getLowReg();
                        bytes[3] = (byte)reg.stReg[_regIndex].getHighReg();
                    }
                    else if (this._floatFmt == FloatFMT.FMT_CDAB)
                    {
                        bytes[0] = (byte)reg.stReg[_regIndex].getLowReg();
                        bytes[1] = (byte)reg.stReg[_regIndex].getHighReg();
                        bytes[2] = (byte)reg.stReg[_regIndex + 1].getLowReg();
                        bytes[3] = (byte)reg.stReg[_regIndex + 1].getHighReg();
                    }
                    else if (this._floatFmt == FloatFMT.FMT_BADC)
                    {
                        bytes[0] = (byte)reg.stReg[_regIndex + 1].getHighReg();
                        bytes[1] = (byte)reg.stReg[_regIndex + 1].getLowReg();
                        bytes[2] = (byte)reg.stReg[_regIndex].getHighReg();
                        bytes[3] = (byte)reg.stReg[_regIndex].getLowReg();
                    }
                    else if (this._floatFmt == FloatFMT.FMT_DCBA)
                    {
                        bytes[0] = (byte)reg.stReg[_regIndex].getHighReg();
                        bytes[1] = (byte)reg.stReg[_regIndex].getLowReg();
                        bytes[2] = (byte)reg.stReg[_regIndex + 1].getHighReg();
                        bytes[3] = (byte)reg.stReg[_regIndex + 1].getLowReg();
                    }
                    else
                    {
                        return;
                    }

                    float q = BitConverter.ToSingle(bytes, 0);
                    this.Text = q.ToString();
                    break;
                default:
                    break;
            }

        }
    }

    class BsItem
    {
        public int index
        {
            get;
            set;
        }

        public string mapstring
        {
            get;
            set;
        }
    }  
}
