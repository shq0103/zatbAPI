using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zatbAPI.Models;

namespace zatbAPI.DbHelper
{
    public class ImageDao : DaoBase<Image, Int32>
    {
        /// <summary>
        /// 获取图片列表
        /// </summary>
        /// <param name="toId">对应id</param>
        /// <param name="type">类型（1.新闻,2.活动，3.闲趣，4.打卡点）</param>
        /// <returns></returns>
        public List<string> GetImageList(int toId,int type)
        {
            List<string> list=new List<string>();
            var imgList = GetList("where toId=@toId and type=@type", new { toId, type });
            foreach(var img in imgList)
            {
                list.Add(img.Url);
            }
            return list;
        }
        /// <summary>
        /// 将图片url数组存入数据库
        /// </summary>
        /// <param name="imgList">url数组</param>
        /// <param name="toId">对应id</param>
        /// <param name="type">类型（1.新闻,2.活动，3.闲趣，4.打卡点）</param>
        /// <returns></returns>
        public int InsertImageList(IEnumerable<string> imgList, int toId, int type)
        {
            int i = 0;
            foreach(var item in imgList)
            {
                i += Insert(new Image { Url = item, ToId = toId, Type = type })??0;
            }
            return i;
        }

        /// <summary>
        /// 更新图片url
        /// </summary>
        /// <param name="imgList"></param>
        /// <param name="toId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public int UpdateImageList(IEnumerable<string> imgList, int toId, int type)
        {
            int i = 0;
            DeleteList("where toId=@toId and type=@type", new { toId, type });
            return InsertImageList(imgList, toId, type);
        }

    }
}
