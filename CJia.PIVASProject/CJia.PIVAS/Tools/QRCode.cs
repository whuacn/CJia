using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ThoughtWorks.QRCode.Codec;

namespace CJia.PIVAS.Tools
{
    /// <summary>
    /// 生成二维码
    /// </summary>
    public static class QRCode
    {
        /// <summary>
        /// 根据用户名返回一个二进制数组
        /// </summary>
        /// <param name="text">存储的信息</param>
        /// <param name="Scale">生成二维码图片的放大倍数</param>
        /// <returns></returns>
        public static Bitmap CreateQRcode(string text, int Scale)
        {
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qrCodeEncoder.QRCodeScale = Scale;
            qrCodeEncoder.QRCodeVersion = 8;
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            String data = text;
            return qrCodeEncoder.Encode(data);
        }
    }
}
