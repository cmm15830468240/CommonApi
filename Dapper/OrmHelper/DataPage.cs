using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.OrmHelper
{
    public class DataPage : INotifyPropertyChanged
    {
        /// <summary>分页页大小0.不分页</summary>
        public const string PageSizeField = "PageSize";

        /// <summary>显示页编码</summary>
        public const string PageIndexField = "PageIndex";

        /// <summary>返回总信息量</summary>
        public const string RowCountField = "RowCount";

        /// <summary>返回总页数 </summary>
        public const string PageCountField = "PageCount";

        /// <summary>排序字段</summary>
        public const string OrderFieldName = "OrderField";

        #region 属性

        static List<string> _Columns = new List<string> { "PageSize", "PageIndex", "RowCount", "PageCount", "OrderField" };

        /// <summary>对象属性名集合</summary>
        public static List<string> Columns
        {
            get { return _Columns; }
        }


        private int _pageSize = 20;

        /// <summary>分页页大小</summary>
        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                _pageSize = value;
                if (_pageSize != 0)
                {
                    if (_rowCount%_pageSize != 0)
                        _pageCount = _pageCount + 1;
                    else
                        _pageCount = (int) (_rowCount/_pageSize);
                }
                OnPropertyChanged("PageSize");
            }
        }

        private Int32 _pageIndex = 1;

        /// <summary>显示页编码 </summary>
        public Int32 PageIndex
        {
            get
            {
                if (_pageIndex <= 0)
                    _pageIndex = 1;
                return _pageIndex;
            }
            set
            {
                _pageIndex = value;
                OnPropertyChanged("PageIndex");
            }
        }

        private Int64 _rowCount;

        /// <summary>返回总信息量</summary>
        public Int64 RowCount
        {
            get { return _rowCount; }
            set
            {
                _rowCount = value;
                if (_pageSize != 0)
                {
                    _pageCount = (int) (_rowCount/_pageSize);
                    if (_rowCount%_pageSize != 0) _pageCount = _pageCount + 1;
                    if (_pageIndex > _pageCount) _pageIndex = _pageCount;
                }
                OnPropertyChanged("RowCount");
            }
        }

        private Int32 _pageCount = 1;

        /// <summary>返回总页数</summary>
        public Int32 PageCount
        {
            get { return _pageCount; }
            set
            {
                _pageCount = value;
                OnPropertyChanged("PageCount");
            }
        }

        /// <summary>排序字段</summary>
        public string OrderField { get; set; }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
