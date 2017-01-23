using System;
using System.Collections.Generic;
using System.Text;
namespace My_Download_Manager
{
    [Serializable()]
    public class AbsDownload : ObjDownload
    {
        #region >- Variable -<
        
        private long loaded = 0;
        private long size = 0;
        private string pathfile = string.Empty;
        private DownloadStatus status;
        [NonSerialized()]
        private bool running = false;

        #endregion

        #region >- Contructure -<

        public AbsDownload()
        {
            Status = DownloadStatus.Create;
        }

        #endregion

        #region >- ObjDownload Members -<

        public AbsDownload(string pathfile, long size)
        {
            this.PathFile = pathfile;
            this.Size = size;
            Status = DownloadStatus.Create;
        }
        public virtual void StartDownload()
        {
        }
        public virtual void StopDownload()
        {
        }
        public void DeleteFile()
        {
            if (System.IO.File.Exists(this.pathfile))
                try
                {
                    System.IO.File.Delete(this.pathfile);
                }
                catch (Exception ex) { }
        }

        #endregion

        #region >- Properties -<

        /// <summary>
        /// Số bytes đã download được
        /// </summary>
        public long Loaded
        {
            get
            {
                return this.loaded;
            }
            set
            {
                this.loaded = value;
            }
        }
        /// <summary>
        /// Kích thước của file
        /// </summary>
        public long Size
        {
            get
            {
                return this.size;
            }
            set
            {
                this.size = value;
            }
        }
        /// <summary>
        /// Đường dẫn lưu file
        /// </summary>
        public virtual string PathFile
        {
            get
            {
                return this.pathfile;
            }
            set
            {
                this.pathfile = value;
            }
        }
        /// <summary>
        /// Trạng thái download của file
        /// </summary>
        public DownloadStatus Status
        {
            get
            {
                return this.status;
            }
            set
            {
                this.status = value;
            }
        }
        /// <summary>
        /// Trạng thái tuyến trình download
        /// </summary>
        public bool Running
        {
            get
            {
                return this.running;
            }
            set
            {
                this.running = value;
            }
        }

        #endregion

    }
}
