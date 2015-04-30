
// CmCaptureOcxDemoDlg.cpp : 实现文件;
//

#include "stdafx.h"
#include "CmCaptureOcxDemo.h"
#include "CmCaptureOcxDemoDlg.h"
#include "afxdialogex.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CCmCaptureOcxDemoDlg 对话框




CCmCaptureOcxDemoDlg::CCmCaptureOcxDemoDlg(CWnd* pParent /*=NULL*/)
	: CDialogEx(CCmCaptureOcxDemoDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CCmCaptureOcxDemoDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);

	DDX_Control(pDX, IDC_CMCAPTUREOCXCTRL1, m_ocx);
	DDX_Control(pDX, IDC_COMBO_DEV, m_DevComb);
	DDX_Control(pDX, IDC_COMBO_ROS, m_ResComb);
	DDX_Control(pDX, IDC_COMBO_MOD, m_clrComb);
	DDX_Control(pDX, IDC_CHECK1, m_autoCheck);
	DDX_Control(pDX, IDC_CHECK2, m_handCheck);
	DDX_Control(pDX, IDC_EDIT1, m_edit);
	DDX_Control(pDX, IDC_CHECK3, m_NoiseCheck);
	DDX_Control(pDX, IDC_COMBO1, m_StyleComb);
	DDX_Control(pDX, IDC_CHECK4, m_BarCheck);
	DDX_Control(pDX, IDC_SLIDER1, m_slider);
	DDX_Control(pDX, IDC_SLIDER2, m_slider2);
	DDX_Control(pDX, IDC_CHECK5, m_check);
	DDX_Control(pDX, IDC_CHECK6, m_check6);
}

BEGIN_MESSAGE_MAP(CCmCaptureOcxDemoDlg, CDialogEx)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDCANCEL, &CCmCaptureOcxDemoDlg::OnBnClickedCancel)
	ON_BN_CLICKED(IDOK2, &CCmCaptureOcxDemoDlg::OnBnClickedOk2)
	ON_CBN_SELCHANGE(IDC_COMBO_DEV, &CCmCaptureOcxDemoDlg::OnCbnSelchangeComboDev)
	ON_CBN_SELCHANGE(IDC_COMBO_ROS, &CCmCaptureOcxDemoDlg::OnCbnSelchangeComboRos)
	ON_CBN_SELCHANGE(IDC_COMBO_MOD, &CCmCaptureOcxDemoDlg::OnCbnSelchangeComboMod)
	ON_BN_CLICKED(IDC_CHECK1, &CCmCaptureOcxDemoDlg::OnBnClickedCheck1)
	ON_BN_CLICKED(IDC_CHECK2, &CCmCaptureOcxDemoDlg::OnBnClickedCheck2)
	ON_CBN_SETFOCUS(IDC_COMBO_DEV, &CCmCaptureOcxDemoDlg::OnCbnSetfocusComboDev)
	ON_BN_CLICKED(IDOK3, &CCmCaptureOcxDemoDlg::OnBnClickedOk3)
	ON_BN_CLICKED(IDOK4, &CCmCaptureOcxDemoDlg::OnBnClickedOk4)
	ON_BN_CLICKED(IDOK5, &CCmCaptureOcxDemoDlg::OnBnClickedOk5)
	ON_BN_CLICKED(IDOK6, &CCmCaptureOcxDemoDlg::OnBnClickedOk6)
	ON_BN_CLICKED(IDC_CHECK3, &CCmCaptureOcxDemoDlg::OnBnClickedCheck3)
	ON_BN_CLICKED(IDC_CHECK4, &CCmCaptureOcxDemoDlg::OnBnClickedCheck4)
	ON_BN_CLICKED(IDOK7, &CCmCaptureOcxDemoDlg::OnBnClickedOk7)
	ON_BN_CLICKED(IDOK8, &CCmCaptureOcxDemoDlg::OnBnClickedOk8)
	ON_BN_CLICKED(IDC_BUTTON1, &CCmCaptureOcxDemoDlg::OnBnClickedButton1)
	ON_BN_CLICKED(IDC_BUTTON2, &CCmCaptureOcxDemoDlg::OnBnClickedButton2)
	ON_BN_CLICKED(IDC_BUTTON4, &CCmCaptureOcxDemoDlg::OnBnClickedButton4)
	ON_BN_CLICKED(IDC_BUTTON3, &CCmCaptureOcxDemoDlg::OnBnClickedButton3)
	ON_BN_CLICKED(IDC_BUTTON5, &CCmCaptureOcxDemoDlg::OnBnClickedButton5)
	ON_BN_CLICKED(IDOK9, &CCmCaptureOcxDemoDlg::OnBnClickedOk9)
	ON_CBN_SELCHANGE(IDC_COMBO1, &CCmCaptureOcxDemoDlg::OnCbnSelchangeCombo1)
	ON_BN_CLICKED(IDOK11, &CCmCaptureOcxDemoDlg::OnBnClickedOk11)
	ON_BN_CLICKED(IDC_BUTTON6, &CCmCaptureOcxDemoDlg::OnBnClickedButton6)
	ON_NOTIFY(NM_CUSTOMDRAW, IDC_SLIDER1, &CCmCaptureOcxDemoDlg::OnNMCustomdrawSlider1)
	ON_NOTIFY(NM_CUSTOMDRAW, IDC_SLIDER2, &CCmCaptureOcxDemoDlg::OnNMCustomdrawSlider2)
	ON_BN_CLICKED(IDC_CHECK5, &CCmCaptureOcxDemoDlg::OnBnClickedCheck5)
	ON_BN_CLICKED(IDC_BUTTON7, &CCmCaptureOcxDemoDlg::OnBnClickedButton7)
	ON_BN_CLICKED(IDOK10, &CCmCaptureOcxDemoDlg::OnBnClickedOk10)
	ON_BN_CLICKED(IDC_BUTTON8, &CCmCaptureOcxDemoDlg::OnBnClickedButton8)
	ON_BN_CLICKED(IDC_BUTTON9, &CCmCaptureOcxDemoDlg::OnBnClickedButton9)
	ON_BN_CLICKED(IDC_BUTTON11, &CCmCaptureOcxDemoDlg::OnBnClickedButton11)
	ON_BN_CLICKED(IDC_BUTTON10, &CCmCaptureOcxDemoDlg::OnBnClickedButton10)
	ON_BN_CLICKED(IDC_CHECK6, &CCmCaptureOcxDemoDlg::OnBnClickedCheck6)
END_MESSAGE_MAP()


// CCmCaptureOcxDemoDlg 消息处理程序;

BOOL CCmCaptureOcxDemoDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// 设置此对话框的图标。当应用程序主窗口不是对话框时，框架将自动;
	//  执行此操作;
	SetIcon(m_hIcon, TRUE);			// 设置大图标;
	SetIcon(m_hIcon, FALSE);		// 设置小图标;

	// TODO: 在此添加额外的初始化代码;
	m_bCrop = FALSE;
	m_DevIndex = 0;
	m_DevNum = -1;
	m_RotateState = 0;

	//m_ocx.Destory();
	int nIndex = m_ocx.Initial();
	if (nIndex == -2)
	{
		AfxMessageBox(L"没有设备或没有授权设备");
		OnCancel();
		return TRUE;
	}
	LONG i = 1600;
	LONG j = 1200;
	m_ocx.StartRunEx(m_DevIndex,320,240,2);
// 	m_DevComb.AddString(L"请选择设备");
// 	m_ResComb.AddString(L"xxxx * xxxx");

	m_DevComb.ResetContent();
	for (int i = 0; i < m_ocx.GetDevCount() ; i++)
	{
		CString temp;
		temp = m_ocx.GetDevFriendName(i);
		m_DevComb.AddString(temp);
	}
	m_DevComb.SetCurSel(m_DevIndex);

	m_ResComb.ResetContent();
	CString strTemp;
	for (int i = 0; i < m_ocx.GetResolutionCount();i ++ )
	{
		strTemp = m_ocx.GetResolution(i);
		m_ResComb.AddString(strTemp);
	}
	m_ResComb.SetCurSel(m_ocx.GetCurResolutionIndex());

/*	m_ocx.SetPaperType(3);*/
// 	m_ResComb.SetCurSel(0);
	m_clrComb.SetCurSel(0);
	m_StyleComb.SetCurSel(0);
	m_autoCheck.SetCheck(0);
	m_BarCheck.SetCheck(0);
	m_NoiseCheck.SetCheck(0);
	m_handCheck.SetCheck(0);
	m_check.SetCheck(1);

	strBrightness= m_ocx.GetBrightnessRange();
	BriMin = _ttoi(strBrightness.Left(strBrightness.Find(L"|")));
	BriMax = _ttoi(strBrightness.Right(strBrightness.GetLength() - strBrightness.Find(L"|") - 1));
	m_slider.SetRange(BriMin,BriMax,TRUE);
	m_slider.SetPos(0);

	strExposure= m_ocx.GetExposureRange();
	ExpMin = _ttoi(strExposure.Left(strExposure.Find(L"|")));
	ExpMax = _ttoi(strExposure.Right(strExposure.GetLength() - strExposure.Find(L"|") - 1));
	m_slider2.SetRange(ExpMin,ExpMax,TRUE);
	m_slider2.SetPos(0);
	return TRUE;  // 除非将焦点设置到控件，否则返回 TRUE;
}

// 如果向对话框添加最小化按钮，则需要下面的代码;
//  来绘制该图标。对于使用文档/视图模型的 MFC 应用程序;
//  这将由框架自动完成;

void CCmCaptureOcxDemoDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // 用于绘制的设备上下文;

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// 使图标在工作区矩形中居中;
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// 绘制图标;
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialogEx::OnPaint();
	}
}

//当用户拖动最小化窗口时系统调用此函数取得光标;
//显示;
HCURSOR CCmCaptureOcxDemoDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}

void CCmCaptureOcxDemoDlg::OnBnClickedCancel()
{
	// TODO: 在此添加控件通知处理程序代码;
	CDialogEx::OnCancel();
}

void CCmCaptureOcxDemoDlg::OnCbnSelchangeComboDev()
{
	m_DevIndex = m_DevComb.GetCurSel();
	m_ocx.StartRun(m_DevIndex);

	m_ResComb.ResetContent();
	CString strTemp;
	for (int i = 0; i < m_ocx.GetResolutionCount();i ++ )
	{
		strTemp = m_ocx.GetResolution(i);
		m_ResComb.AddString(strTemp);
	}
	m_ResComb.SetCurSel(m_ocx.GetCurResolutionIndex());
}

void CCmCaptureOcxDemoDlg::OnCbnSelchangeComboRos()
{
	// TODO: 在此添加控件通知处理程序代码;
	m_ocx.SetResolution(m_ResComb.GetCurSel());
}

void CCmCaptureOcxDemoDlg::OnCbnSelchangeComboMod()
{
	// TODO: 在此添加控件通知处理程序代码;
	m_ocx.SetImageColorMode(m_clrComb.GetCurSel());
}

void CCmCaptureOcxDemoDlg::OnCbnSetfocusComboDev()
{
	// TODO: 在此添加控件通知处理程序代码;

	//m_DevComb.SetCurSel(m_DevIndex);
}

void CCmCaptureOcxDemoDlg::OnBnClickedOk2()
{
// 	CString str11 = m_ocx.Base64Encode(L"C:\\1.bmp");
// 	m_ocx.Base64Decode(str11,L"C:\\11.bmp");

	int i = m_StyleComb.GetCurSel();
	m_ocx.SetFileType(i);
//	m_ocx.SetMarkPic(L"C:\\1.jpg");
	static int k = 0;
	CString str = L"";
	str.Format(L"%d",k);
	strImgName = L"C:\\test\\Img"+str;
	switch(i)
	{
	case 0:
		strImgName += L".bmp";
		break;
	case 1:
		strImgName += L".jpg";
		break;
	case 2:
		strImgName += L".tif";
		break;
	case 3:
		strImgName += L".png";
	}
	int index = m_ocx.CaptureImage(strImgName);
	k++;
}

void CCmCaptureOcxDemoDlg::OnBnClickedOk3()
{
	// TODO: 在此添加控件通知处理程序代码;
	m_ocx.StartVideo (L"C:\\testVideo.avi",true);
}

void CCmCaptureOcxDemoDlg::OnBnClickedOk4()
{
	// TODO: 在此添加控件通知处理程序代码;
	m_ocx.EndVideo();	
}

void CCmCaptureOcxDemoDlg::OnBnClickedOk5()
{
	// TODO: 在此添加控件通知处理程序代码;
	m_ocx.ShowImageSettingWindow();
}

void CCmCaptureOcxDemoDlg::OnBnClickedOk6()
{
	// TODO: 在此添加控件通知处理程序代码;
	CString str;
	m_edit.GetWindowText(str);
	m_ocx.UploadFile(strImgName,1,L"192.168.1.116",L"123",L"123",str);
	//m_ocx.UpdataFile(str,strImgName,FALSE);
}

void CCmCaptureOcxDemoDlg::OnBnClickedOk7()
{
	// TODO: 在此添加控件通知处理程序代码;
	
	int i = m_StyleComb.GetCurSel();
// 	switch(i)
// 	{
// 	case 0:
// 		m_ocx.PreviewFile(strPath + L".bmp");
// 		break;
// 	case 1:
// 		m_ocx.PreviewFile(strPath + L".jpg");
// 		break;
// 	case 2:
// 		m_ocx.PreviewFile(strPath + L".tif");
// 		break;
// 	case 3:
// 		m_ocx.PreviewFile(strPath + L".png");
// 	}
	if (strImgName == L"")
	{
		AfxMessageBox(L"Illegal File Name!");
		return;
	}
	m_ocx.PreviewFile(strImgName);
}

void CCmCaptureOcxDemoDlg::OnBnClickedOk8()
{
	// TODO: 在此添加控件通知处理程序代码;
// 	int i = m_StyleComb.GetCurSel();
// 	switch(i)
// 	{
// 	case 0:
// 		m_ocx.DeleteFile(L"C:\\Img.bmp");
// 		break;
// 	case 1:
// 		m_ocx.DeleteFile(L"C:\\Img.jpg");
// 		break;
// 	case 2:
// 		m_ocx.DeleteFile(L"C:\\Img.tif");
// 		break;
// 	case 3:
// 		m_ocx.DeleteFile(L"C:\\Img.png");
	// 	}
	if (strImgName == L"")
	{
		AfxMessageBox(L"Illegal File Name!");
		return;
	}
	m_ocx.DeleteFile(strImgName);
	strImgName = L"";
}

void CCmCaptureOcxDemoDlg::OnBnClickedOk9()
{
	// TODO: 在此添加控件通知处理程序代码;
	m_ocx.SeriesCapture(TRUE,L"C:\\test\\");
}

void CCmCaptureOcxDemoDlg::OnBnClickedOk10()
{
	// TODO: 在此添加控件通知处理程序代码;
	m_ocx.TimimgCapture(TRUE,L"C:\\test\\",1000);
}

void CCmCaptureOcxDemoDlg::OnBnClickedOk11()
{
	// TODO: 在此添加控件通知处理程序代码;
	int FileIndex = m_ocx.GetSerImgFileCount();
	for (int i = 0; i < FileIndex ; i++)
	{
		CString str = m_ocx.GetSerImgFileNameAt(i);
		AfxMessageBox(str);
	}
}

void CCmCaptureOcxDemoDlg::OnBnClickedCheck1()
{
	// TODO: 在此添加控件通知处理程序代码;
	if (m_autoCheck.GetCheck())
	{
//		m_ocx.OpenAutomaticExposure(1);
//		m_ocx.SetCropMode(0);
		m_ocx.AutoCrop(TRUE);
	}
	else
	{
		m_ocx.AutoCrop(FALSE);
		m_ocx.OpenAutomaticExposure(0);
	}
}

void CCmCaptureOcxDemoDlg::OnBnClickedCheck2()
{
	// TODO: 在此添加控件通知处理程序代码;
	if (m_handCheck.GetCheck())
	{
		m_ocx.CusCrop(TRUE);
	}
	else
		m_ocx.CusCrop(FALSE);
}

void CCmCaptureOcxDemoDlg::OnBnClickedCheck3()
{
	// TODO: 在此添加控件通知处理程序代码;
	if (m_NoiseCheck.GetCheck())
	{
		m_ocx.SetDenoise(TRUE);
	}
	else
		m_ocx.SetDenoise(FALSE);
}

void CCmCaptureOcxDemoDlg::OnBnClickedCheck4()
{
	// TODO: 在此添加控件通知处理程序代码;
	if (m_BarCheck.GetCheck())
	{
		m_ocx.ReadBarCode(TRUE);
	}
	else
		m_ocx.ReadBarCode(FALSE);
}

void CCmCaptureOcxDemoDlg::OnBnClickedCheck5()
{
	// TODO: 在此添加控件通知处理程序代码;
	m_ocx.AutoExposure(m_check.GetCheck());
	if (m_check.GetCheck())
	{
		m_slider2.EnableWindow(FALSE);
	}
	else
	{
		m_slider2.EnableWindow(TRUE);
	}
}

void CCmCaptureOcxDemoDlg::OnBnClickedButton1()
{
	// TODO: 在此添加控件通知处理程序代码;
	m_ocx.Destory();
}

void CCmCaptureOcxDemoDlg::OnBnClickedButton2()
{
	// TODO: 在此添加控件通知处理程序代码;
	m_ocx.Initial();
	m_ocx.StartRunEx(m_DevIndex,1600,1200,1);
	m_ResComb.ResetContent();
	CString strTemp;
	for (int i = 0; i < m_ocx.GetResolutionCount();i ++ )
	{
		strTemp = m_ocx.GetResolution(i);
		m_ResComb.AddString(strTemp);
	}
	m_ResComb.SetCurSel(m_ocx.GetCurResolutionIndex());

}

void CCmCaptureOcxDemoDlg::OnBnClickedButton4()
{
	// TODO: 在此添加控件通知处理程序代码;
	m_RotateState++;
	if (m_RotateState == 4)
	{
		m_RotateState = 0;
	}
	m_ocx.RotateVideo(m_RotateState);

}

void CCmCaptureOcxDemoDlg::OnBnClickedButton3()
{
	// TODO: 在此添加控件通知处理程序代码;
	m_RotateState--;
	if (m_RotateState == -1)
	{
		m_RotateState = 3;
	}
	m_ocx.RotateVideo(m_RotateState);

}

void CCmCaptureOcxDemoDlg::OnBnClickedButton5()
{
	m_ocx.AutoFocus();
}

void CCmCaptureOcxDemoDlg::OnBnClickedButton6()
{
	// TODO: 在此添加控件通知处理程序代码;
	CString str;
	str = m_ocx.CaptureToBase64();
	CString base64FileName =  L"C:\\base64.txt";
	try
	{
		//设置文件的打开参数;
		CStdioFile outFile(base64FileName, CFile::modeNoTruncate | CFile::modeCreate | CFile::modeWrite | CFile::typeText);
		//在文件末尾插入新纪录;
		outFile.SeekToEnd();
		outFile.WriteString( str );
		outFile.Close();
	}
	catch(CFileException *fx)
	{
		fx->Delete();
	}
}

void CCmCaptureOcxDemoDlg::OnBnClickedButton7()
{
	// TODO: 在此添加控件通知处理程序代码;
//	m_ocx.SetJpgQuanlity(80);
// 	BYTE* pTempBuf = NULL;
// 	LONG width,height,effwidth;
// 	m_ocx.CaptureToBinary(pTempBuf,&width,&height,&effwidth);
// 	pTempBuf = new BYTE[height * effwidth];
// 	if(!m_ocx.CaptureToBinary(pTempBuf,&width,&height,&effwidth))
// 	{
// 		Sleep(100);
// 		delete pTempBuf;
// 		pTempBuf = NULL;
// 		//return FALSE;
// 	}
	//m_ocx.AdjustExposure();
	//m_ocx.SetJpgQuanlity(80);
// 	m_ocx.Destory();
// 	while (1)
// 	{
// 		m_ocx.Initial();
// 		m_ocx.StartRun(0);
// 		Sleep(10000);
// 		m_ocx.Destory();
// 		Sleep(2000);;
// 	}

// 	m_ocx.TrueSize();
//	m_ocx.BestSize();
//	CString str = m_ocx.CaptureImageEx(L"coffee.bmp");
// 	m_ocx.SetCurrentDevDPI(228.71311,228.93427);
// 	m_ocx.SetImageDPI(100);
// 	m_ocx.SetFileType(1);
// 	m_ocx.CaptureImage(L"d:\\temp\\DPIimage.jpg");
//	m_ocx.SetTimeMark(L"",30);
//	m_ocx.AddPDFImageFile(strImgName);
//	long w,h,b;
//	long size = m_ocx.GetLastImageInfo(strImgName);
//	CString str;
//	str.Format(L"%d",size);
//	AfxMessageBox(str);
// 	if (m_ocx.UploadFile(strImgName,1,L"192.168.1.151",L"123",L"123",L"\\temp\\1.bmp") != 0)
// 	{
// 		AfxMessageBox(L"Upload error");
// 	}

	DWORD colorRef = RGB(255,0,255);
	m_ocx.SetMarkStringEx(0,50,L"北京麦哲",colorRef,1,10,10,1);
} 

void CCmCaptureOcxDemoDlg::OnBnClickedButton8()
{
	// TODO: 在此添加控件通知处理程序代码;
	//m_ocx.TrueSize();
	//m_ocx.ZoomIn();
	m_ocx.SetJpgQuanlity(90);
}

void CCmCaptureOcxDemoDlg::OnBnClickedButton9()
{
	// TODO: 在此添加控件通知处理程序代码;
	//m_ocx.Convert2PDF(L"c:\\test\\1.pdf",0);
	//m_ocx.BestSize();
	//m_ocx.ZoomOut();
	m_ocx.SetJpgQuanlity(40);
}

void CCmCaptureOcxDemoDlg::OnCbnSelchangeCombo1()
{
	// TODO: 在此添加控件通知处理程序代码;
	int i = m_StyleComb.GetCurSel();
	m_ocx.SetFileType(i);
}

void CCmCaptureOcxDemoDlg::CaptureToBinary()
{

	BYTE * src = NULL;
	long width,height,lineLength;
	m_ocx.CaptureToBinary(src,&width,&height,&lineLength);
	src = new BYTE[lineLength * height];
	m_ocx.CaptureToBinary(src,&width,&height,&lineLength);

	int bpp = lineLength / width * 8;
	int colorUse = 0;
	if (bpp == 0)
	{
		bpp = 1;
	}
	switch(bpp)
	{
	case 1:
		colorUse = 2;
		break;
	case 4:
		colorUse = 16;
		break;
	case 8:
		colorUse = 256;
		break;
	case 24:
		colorUse = 0;
		break;

	}

	//以二进制写的方式打开文件
	FILE *fp=fopen("C:\\ImageBuff.bmp","wb");
	if(fp == 0) 
		return;


	//申请位图文件头结构变量，填写文件头信息
	BITMAPFILEHEADER fileHead;
	fileHead.bfType = 0x4D42;//bmp类型

	//bfSize是图像文件4个组成部分之和
	fileHead.bfSize= sizeof(BITMAPFILEHEADER) + sizeof(BITMAPINFOHEADER)
		+ lineLength*height;
	fileHead.bfReserved1 = 0;
	fileHead.bfReserved2 = 0;

	//bfOffBits是图像文件前三个部分所需空间之和
	fileHead.bfOffBits = sizeof(BITMAPFILEHEADER) + sizeof(BITMAPINFOHEADER);

	//写文件头进文件
	fwrite(&fileHead, sizeof(BITMAPFILEHEADER),1, fp);

	//申请位图信息头结构变量，填写信息头信息
	BITMAPINFOHEADER head;
	head.biBitCount=bpp;
	head.biClrImportant=0;
	head.biClrUsed = colorUse;
	head.biCompression = BI_RGB;
	head.biWidth=width;
	head.biHeight=height;
	head.biPlanes=1;
	head.biSize=sizeof(BITMAPINFOHEADER);;
	head.biSizeImage=lineLength*height;
	head.biXPelsPerMeter=0;
	head.biYPelsPerMeter=0;

	//写位图信息头进内存
	fwrite(&head, sizeof(BITMAPINFOHEADER),1, fp);

	if (bpp == 8)
	{
		RGBQUAD *pRgb;
		DWORD dwTargetSize=sizeof(RGBQUAD)*256;
		PBYTE pTarget=(PBYTE)VirtualAlloc(NULL,dwTargetSize,MEM_COMMIT,PAGE_READWRITE);
		memset(pTarget,0,dwTargetSize);
		for(int i=0;i<256;i++)//初始化8位灰度图的调色板信息
		{
			pRgb = (RGBQUAD*)(pTarget + i*sizeof(RGBQUAD));
			pRgb->rgbBlue=i;pRgb->rgbGreen=i;pRgb->rgbRed=i;pRgb->rgbReserved=0;
		}
		fwrite(pTarget, dwTargetSize, 1, fp);
		VirtualFree(pTarget,NULL,MEM_RELEASE);
	}
	if (bpp == 1)
	{
		RGBQUAD *pRgb;
		DWORD dwTargetSize=sizeof(RGBQUAD)*2;
		PBYTE pTarget=(PBYTE)VirtualAlloc(NULL,dwTargetSize,MEM_COMMIT,PAGE_READWRITE);
		memset(pTarget,0,dwTargetSize);
		for(int i=0;i<2;i++)//初始化二值化的调色板信息
		{
			pRgb = (RGBQUAD*)(pTarget+i*sizeof(RGBQUAD));
			pRgb->rgbBlue= i * 255;pRgb->rgbGreen = i * 255;pRgb->rgbRed = i* 255;pRgb->rgbReserved=0;
		}
		fwrite(pTarget, dwTargetSize, 1, fp);
		VirtualFree(pTarget,NULL,MEM_RELEASE);
	}
	//写位图数据进文件
	fwrite(src, height * lineLength, 1, fp);

	//关闭文件
	fclose(fp);

	delete src;
}

void CCmCaptureOcxDemoDlg::OnNMCustomdrawSlider1(NMHDR *pNMHDR, LRESULT *pResult)
{
	LPNMCUSTOMDRAW pNMCD = reinterpret_cast<LPNMCUSTOMDRAW>(pNMHDR);
	// TODO: 在此添加控件通知处理程序代码;	
	CString str = m_ocx.GetBrightnessRange();
	int n = str.Find('|');
	CString str1 = str.Left(n);
	CString str2 = str.Right(str.GetLength() - n -1);
	int value = _wtoi(str1);
	int value1 = _wtoi(str2);
	m_slider.SetPos((value1+value)/2);
	int i = m_slider.GetPos();
	m_ocx.SetBrightness(i);
	*pResult = 0;
}

void CCmCaptureOcxDemoDlg::OnNMCustomdrawSlider2(NMHDR *pNMHDR, LRESULT *pResult)
{
	LPNMCUSTOMDRAW pNMCD = reinterpret_cast<LPNMCUSTOMDRAW>(pNMHDR);
	// TODO: 在此添加控件通知处理程序代码;
	int i = m_slider2.GetPos();
	m_ocx.SetExposure(i);
	*pResult = 0;
}

// 
// void CCmCaptureOcxDemoDlg::OnBnClickedIccard()
// {
// 	CICCard ic;
// 	ic.DoModal();
// }
// 
// 
// void CCmCaptureOcxDemoDlg::OnBnClickedButton10()
// {
// 	// TODO: 在此添加控件通知处理程序代码;
// 	TCHAR lpTempPathBuffer[MAX_PATH];
// 	GetTempPath(256, lpTempPathBuffer);
// 	CString savePath = lpTempPathBuffer;
// 	savePath += L"IDReader.bmp";
// 	m_ocx.CaptureImage(savePath);
// 	m_IDReader.SetICPic(savePath);
// 	m_IDReader.RecognitionICCard();
// 	CString year = m_IDReader.GetYear();
// 	CString month = m_IDReader.GetMonth();
// 	CString day = m_IDReader.GetDay();
// 
// 	CString Temp_str = year + L"-" + month + L"-" + day;
// 
// 	CICCard ic;
// 	ic.SetNameString(m_IDReader.GetName());
// 	ic.SetBirthString(Temp_str);
// 	ic.SetDateString(m_IDReader.GetExpiryDate());
// 	ic.SetHeadPicString(m_IDReader.GetHeadPicPath());
// 	ic.SetNationString(m_IDReader.GetMZ());
// 	ic.SetICNOString(m_IDReader.GetICNO());
// 	ic.SetAddString(m_IDReader.GetAddr());
// 	ic.SetOfficeString(m_IDReader.GetAuthorization());
// 	ic.SetSexString(m_IDReader.GetSex());
// 
// 	ic.DoModal();
// 
// }
BEGIN_EVENTSINK_MAP(CCmCaptureOcxDemoDlg, CDialogEx)
	ON_EVENT(CCmCaptureOcxDemoDlg, IDC_CMCAPTUREOCXCTRL1, 1, CCmCaptureOcxDemoDlg::GetImageFileNameCmcaptureocxctrl1, VTS_BSTR)
END_EVENTSINK_MAP()


void CCmCaptureOcxDemoDlg::GetImageFileNameCmcaptureocxctrl1(LPCTSTR FileName)
{
	// TODO: 在此处添加消息处理程序代码;
	strImgName = FileName;
}


void CCmCaptureOcxDemoDlg::OnBnClickedButton11()
{
	// TODO: Add your control notification handler code here
	CString str = m_ocx.GetDevSN(0);
	AfxMessageBox(str);
}


void CCmCaptureOcxDemoDlg::OnBnClickedButton10()
{
	// TODO: Add your control notification handler code here
	AfxMessageBox(m_ocx.GetCodeString());

}


void CCmCaptureOcxDemoDlg::OnBnClickedCheck6()
{
	// TODO: Add your control notification handler code here
	if (m_check6.GetCheck())
	{
		m_ocx.OpenAutomaticExposure(TRUE);
	}
	else
	{
		m_ocx.OpenAutomaticExposure(FALSE);
	}
	
}
