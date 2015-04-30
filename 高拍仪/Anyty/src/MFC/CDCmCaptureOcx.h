// CDCmCaptureOcx.h  : Declaration of ActiveX Control wrapper class(es) created by Microsoft Visual C++

#pragma once

/////////////////////////////////////////////////////////////////////////////
// CDCmCaptureOcx

class CDCmCaptureOcx : public CWnd
{
protected:
	DECLARE_DYNCREATE(CDCmCaptureOcx)
public:
	CLSID const& GetClsid()
	{
		static CLSID const clsid
			= { 0x3CA842C5, 0x9B56, 0x4329, { 0xA7, 0xCA, 0x35, 0xCA, 0x77, 0xC7, 0x12, 0x8D } };
		return clsid;
	}
	virtual BOOL Create(LPCTSTR lpszClassName, LPCTSTR lpszWindowName, DWORD dwStyle,
						const RECT& rect, CWnd* pParentWnd, UINT nID, 
						CCreateContext* pContext = NULL)
	{ 
		return CreateControl(GetClsid(), lpszWindowName, dwStyle, rect, pParentWnd, nID); 
	}

    BOOL Create(LPCTSTR lpszWindowName, DWORD dwStyle, const RECT& rect, CWnd* pParentWnd, 
				UINT nID, CFile* pPersist = NULL, BOOL bStorage = FALSE,
				BSTR bstrLicKey = NULL)
	{ 
		return CreateControl(GetClsid(), lpszWindowName, dwStyle, rect, pParentWnd, nID,
		pPersist, bStorage, bstrLicKey); 
	}

// Attributes
public:

// Operations
public:

	void AboutBox()
	{
		InvokeHelper(DISPID_ABOUTBOX, DISPATCH_METHOD, VT_EMPTY, NULL, NULL);
	}
	CString HelloWorld(long __MIDL___DCmCaptureOcx0000, LPCTSTR __MIDL___DCmCaptureOcx0001)
	{
		CString result;
		static BYTE parms[] = VTS_I4 VTS_BSTR ;
		InvokeHelper(0x1, DISPATCH_METHOD, VT_BSTR, (void*)&result, parms, __MIDL___DCmCaptureOcx0000, __MIDL___DCmCaptureOcx0001);
		return result;
	}
	long AutoCrop(long bAutoCrop)
	{
		long result;
		static BYTE parms[] = VTS_I4 ;
		InvokeHelper(0x2, DISPATCH_METHOD, VT_I4, (void*)&result, parms, bAutoCrop);
		return result;
	}
	long AutoFocus()
	{
		long result;
		InvokeHelper(0x3, DISPATCH_METHOD, VT_I4, (void*)&result, NULL);
		return result;
	}
	long CaptureImage(LPCTSTR ImgPath)
	{
		long result;
		static BYTE parms[] = VTS_BSTR ;
		InvokeHelper(0x4, DISPATCH_METHOD, VT_I4, (void*)&result, parms, ImgPath);
		return result;
	}
	long CusCrop(long bCusCrop)
	{
		long result;
		static BYTE parms[] = VTS_I4 ;
		InvokeHelper(0x5, DISPATCH_METHOD, VT_I4, (void*)&result, parms, bCusCrop);
		return result;
	}
	long DeleteFile(LPCTSTR FilePath)
	{
		long result;
		static BYTE parms[] = VTS_BSTR ;
		InvokeHelper(0x6, DISPATCH_METHOD, VT_I4, (void*)&result, parms, FilePath);
		return result;
	}
	long Destory()
	{
		long result;
		InvokeHelper(0x7, DISPATCH_METHOD, VT_I4, (void*)&result, NULL);
		return result;
	}
	void EndVideo()
	{
		InvokeHelper(0x8, DISPATCH_METHOD, VT_EMPTY, NULL, NULL);
	}
	long GetCurResolutionIndex()
	{
		long result;
		InvokeHelper(0x9, DISPATCH_METHOD, VT_I4, (void*)&result, NULL);
		return result;
	}
	long GetDevCount()
	{
		long result;
		InvokeHelper(0xa, DISPATCH_METHOD, VT_I4, (void*)&result, NULL);
		return result;
	}
	CString GetDevFriendName(long DevIndex)
	{
		CString result;
		static BYTE parms[] = VTS_I4 ;
		InvokeHelper(0xb, DISPATCH_METHOD, VT_BSTR, (void*)&result, parms, DevIndex);
		return result;
	}
	CString GetResolution(long ResIndex)
	{
		CString result;
		static BYTE parms[] = VTS_I4 ;
		InvokeHelper(0xc, DISPATCH_METHOD, VT_BSTR, (void*)&result, parms, ResIndex);
		return result;
	}
	long GetResolutionCount()
	{
		long result;
		InvokeHelper(0xd, DISPATCH_METHOD, VT_I4, (void*)&result, NULL);
		return result;
	}
	long GetSerImgFileCount()
	{
		long result;
		InvokeHelper(0xe, DISPATCH_METHOD, VT_I4, (void*)&result, NULL);
		return result;
	}
	CString GetSerImgFileNameAt(long FileNameIndex)
	{
		CString result;
		static BYTE parms[] = VTS_I4 ;
		InvokeHelper(0xf, DISPATCH_METHOD, VT_BSTR, (void*)&result, parms, FileNameIndex);
		return result;
	}
	long Initial()
	{
		long result;
		InvokeHelper(0x10, DISPATCH_METHOD, VT_I4, (void*)&result, NULL);
		return result;
	}
	long PreviewFile(LPCTSTR FilePath)
	{
		long result;
		static BYTE parms[] = VTS_BSTR ;
		InvokeHelper(0x11, DISPATCH_METHOD, VT_I4, (void*)&result, parms, FilePath);
		return result;
	}
	long ReadBarCode(long bReadBar)
	{
		long result;
		static BYTE parms[] = VTS_I4 ;
		InvokeHelper(0x12, DISPATCH_METHOD, VT_I4, (void*)&result, parms, bReadBar);
		return result;
	}
	long RotateVideo(long RotIndex)
	{
		long result;
		static BYTE parms[] = VTS_I4 ;
		InvokeHelper(0x13, DISPATCH_METHOD, VT_I4, (void*)&result, parms, RotIndex);
		return result;
	}
	long SeriesCapture(long bSerCap, LPCTSTR FilePath)
	{
		long result;
		static BYTE parms[] = VTS_I4 VTS_BSTR ;
		InvokeHelper(0x14, DISPATCH_METHOD, VT_I4, (void*)&result, parms, bSerCap, FilePath);
		return result;
	}
	long SetDenoise(long bDenoise)
	{
		long result;
		static BYTE parms[] = VTS_I4 ;
		InvokeHelper(0x15, DISPATCH_METHOD, VT_I4, (void*)&result, parms, bDenoise);
		return result;
	}
	long SetFileType(long FileIndex)
	{
		long result;
		static BYTE parms[] = VTS_I4 ;
		InvokeHelper(0x16, DISPATCH_METHOD, VT_I4, (void*)&result, parms, FileIndex);
		return result;
	}
	long SetImageColorMode(long ClrIndex)
	{
		long result;
		static BYTE parms[] = VTS_I4 ;
		InvokeHelper(0x17, DISPATCH_METHOD, VT_I4, (void*)&result, parms, ClrIndex);
		return result;
	}
	long SetJpgQuanlity(long QuaNum)
	{
		long result;
		static BYTE parms[] = VTS_I4 ;
		InvokeHelper(0x18, DISPATCH_METHOD, VT_I4, (void*)&result, parms, QuaNum);
		return result;
	}
	long SetResolution(long ResIndex)
	{
		long result;
		static BYTE parms[] = VTS_I4 ;
		InvokeHelper(0x19, DISPATCH_METHOD, VT_I4, (void*)&result, parms, ResIndex);
		return result;
	}
	long ShowImageSettingWindow()
	{
		long result;
		InvokeHelper(0x1a, DISPATCH_METHOD, VT_I4, (void*)&result, NULL);
		return result;
	}
	long StartRun(long bStartRun)
	{
		long result;
		static BYTE parms[] = VTS_I4 ;
		InvokeHelper(0x1b, DISPATCH_METHOD, VT_I4, (void*)&result, parms, bStartRun);
		return result;
	}
	long StartVideo(LPCTSTR VideoPath, long bAudio)
	{
		long result;
		static BYTE parms[] = VTS_BSTR VTS_I4 ;
		InvokeHelper(0x1c, DISPATCH_METHOD, VT_I4, (void*)&result, parms, VideoPath, bAudio);
		return result;
	}
	long UpdataFile(LPCTSTR URLPath, LPCTSTR FilePath, long bFileDelete)
	{
		long result;
		static BYTE parms[] = VTS_BSTR VTS_BSTR VTS_I4 ;
		InvokeHelper(0x1d, DISPATCH_METHOD, VT_I4, (void*)&result, parms, URLPath, FilePath, bFileDelete);
		return result;
	}
	long ZoomIn()
	{
		long result;
		InvokeHelper(0x1e, DISPATCH_METHOD, VT_I4, (void*)&result, NULL);
		return result;
	}
	long ZoomOut()
	{
		long result;
		InvokeHelper(0x1f, DISPATCH_METHOD, VT_I4, (void*)&result, NULL);
		return result;
	}
	CString CaptureToBase64()
	{
		CString result;
		InvokeHelper(0x20, DISPATCH_METHOD, VT_BSTR, (void*)&result, NULL);
		return result;
	}
	long CaptureToBinary(unsigned char * lpBuf, long * Width, long * Height, long * nLzzine)
	{
		long result;
		static BYTE parms[] = VTS_PUI1 VTS_PI4 VTS_PI4 VTS_PI4 ;
		InvokeHelper(0x21, DISPATCH_METHOD, VT_I4, (void*)&result, parms, lpBuf, Width, Height, nLzzine);
		return result;
	}
	long SetBrightness(long BriNum)
	{
		long result;
		static BYTE parms[] = VTS_I4 ;
		InvokeHelper(0x22, DISPATCH_METHOD, VT_I4, (void*)&result, parms, BriNum);
		return result;
	}
	long SetExposure(long ExpNum)
	{
		long result;
		static BYTE parms[] = VTS_I4 ;
		InvokeHelper(0x23, DISPATCH_METHOD, VT_I4, (void*)&result, parms, ExpNum);
		return result;
	}
	long AutoExposure(long bExp)
	{
		long result;
		static BYTE parms[] = VTS_I4 ;
		InvokeHelper(0x24, DISPATCH_METHOD, VT_I4, (void*)&result, parms, bExp);
		return result;
	}
	CString GetBrightnessRange()
	{
		CString result;
		InvokeHelper(0x25, DISPATCH_METHOD, VT_BSTR, (void*)&result, NULL);
		return result;
	}
	CString GetExposureRange()
	{
		CString result;
		InvokeHelper(0x26, DISPATCH_METHOD, VT_BSTR, (void*)&result, NULL);
		return result;
	}
	long FrozenVideo(long bFrozen)
	{
		long result;
		static BYTE parms[] = VTS_I4 ;
		InvokeHelper(0x27, DISPATCH_METHOD, VT_I4, (void*)&result, parms, bFrozen);
		return result;
	}
	long StartRunEx(long DevIndex, long ResWidth, long ResHeight, long RunMode)
	{
		long result;
		static BYTE parms[] = VTS_I4 VTS_I4 VTS_I4 VTS_I4 ;
		InvokeHelper(0x28, DISPATCH_METHOD, VT_I4, (void*)&result, parms, DevIndex, ResWidth, ResHeight, RunMode);
		return result;
	}
	void SetImageDPI(long ndpi)
	{
		static BYTE parms[] = VTS_I4 ;
		InvokeHelper(0x29, DISPATCH_METHOD, VT_EMPTY, NULL, parms, ndpi);
	}
	long TimimgCapture(long bTimeCap, LPCTSTR FilePath, long IntevialTime)
	{
		long result;
		static BYTE parms[] = VTS_I4 VTS_BSTR VTS_I4 ;
		InvokeHelper(0x2a, DISPATCH_METHOD, VT_I4, (void*)&result, parms, bTimeCap, FilePath, IntevialTime);
		return result;
	}
	void Convert2PDF(LPCTSTR strNew, long mode)
	{
		static BYTE parms[] = VTS_BSTR VTS_I4 ;
		InvokeHelper(0x2b, DISPATCH_METHOD, VT_EMPTY, NULL, parms, strNew, mode);
	}
	long AddPDFImageFile(LPCTSTR imagefile)
	{
		long result;
		static BYTE parms[] = VTS_BSTR ;
		InvokeHelper(0x2c, DISPATCH_METHOD, VT_I4, (void*)&result, parms, imagefile);
		return result;
	}
	void DragVideo(long Drag)
	{
		static BYTE parms[] = VTS_I4 ;
		InvokeHelper(0x2d, DISPATCH_METHOD, VT_EMPTY, NULL, parms, Drag);
	}
	void SetMarkPic(LPCTSTR FilePath, long Alpha)
	{
		static BYTE parms[] = VTS_BSTR VTS_I4 ;
		InvokeHelper(0x2e, DISPATCH_METHOD, VT_EMPTY, NULL, parms, FilePath, Alpha);
	}
	void GetPreviewImg(unsigned char * lpBuf, long * Width, long * Height, long * nLine)
	{
		static BYTE parms[] = VTS_PUI1 VTS_PI4 VTS_PI4 VTS_PI4 ;
		InvokeHelper(0x2f, DISPATCH_METHOD, VT_EMPTY, NULL, parms, lpBuf, Width, Height, nLine);
	}
	long SetPaperType(long type)
	{
		long result;
		static BYTE parms[] = VTS_I4 ;
		InvokeHelper(0x30, DISPATCH_METHOD, VT_I4, (void*)&result, parms, type);
		return result;
	}
	long AdjustExposure()
	{
		long result;
		InvokeHelper(0x31, DISPATCH_METHOD, VT_I4, (void*)&result, NULL);
		return result;
	}


};
