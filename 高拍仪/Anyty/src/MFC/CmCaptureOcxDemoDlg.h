
// CmCaptureOcxDemoDlg.h : ͷ�ļ�
//

#pragma once
#include "afxwin.h"
#include "afxcmn.h"
#include "CDCmCaptureOcx.h" 





// CCmCaptureOcxDemoDlg �Ի���
class CCmCaptureOcxDemoDlg : public CDialogEx
{
// ����
public:
	CCmCaptureOcxDemoDlg(CWnd* pParent = NULL);	// ��׼���캯��

// �Ի�������
	enum { IDD = IDD_CMCAPTUREOCXDEMO_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV ֧��
	void OpenFile(CString FileName);

// ʵ��
protected:
	HICON m_hIcon;

	// ���ɵ���Ϣӳ�亯��
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnBnClickedOk();
	afx_msg void OnBnClickedCancel();
	afx_msg void OnBnClickedOk2();

	CDCmCaptureOcx m_ocx;
	BOOL m_bCrop;										//�Ƿ����ֶ�����;
	int m_DevIndex;								//��¼�Ѿ�ѡ����豸;
	int m_RotateState;
	int BriMin,BriMax;
	int ExpMin,ExpMax;
	CComboBox m_DevComb;
	CComboBox m_ResComb;
	CComboBox m_clrComb;
	CButton m_autoCheck;
	CButton m_handCheck;
	CString strPath;
	CString strBrightness;
	CString strExposure;
	int m_DevNum;

/*	CSliderCtrl m_Slider;*/
	CEdit m_edit;

	afx_msg void OnCbnSelchangeComboDev();
	afx_msg void OnCbnSelchangeComboRos();
	afx_msg void OnCbnSelchangeComboMod();
	afx_msg void OnBnClickedCheck1();
	afx_msg void OnBnClickedCheck2();
//	afx_msg void OnNMCustomdrawSlider1(NMHDR *pNMHDR, LRESULT *pResult);
	afx_msg void OnCbnSetfocusComboDev();
	afx_msg void OnBnClickedOk3();
	afx_msg void OnBnClickedOk4();
	afx_msg void OnBnClickedOk5();
	afx_msg void OnBnClickedOk6();
	afx_msg void OnBnClickedCheck3();
	CButton m_NoiseCheck;
	CComboBox m_StyleComb;
	afx_msg void OnBnClickedCheck4();
	CButton m_BarCheck;
	afx_msg void OnBnClickedOk7();
	afx_msg void OnBnClickedOk8();
	afx_msg void OnBnClickedButton1();
	afx_msg void OnBnClickedButton2();
	afx_msg void OnBnClickedRadio1();
	afx_msg void OnBnClickedButton4();
	afx_msg void OnBnClickedButton3();
	afx_msg void OnBnClickedButton5();
	afx_msg void OnBnClickedOk9();
	afx_msg void OnCbnSelchangeCombo1();
	afx_msg void OnBnClickedOk11();
	afx_msg void OnBnClickedButton6();
	afx_msg void OnBnClickedOk10();
private:
	void CaptureToBinary();
public:
	afx_msg void OnNMCustomdrawSlider1(NMHDR *pNMHDR, LRESULT *pResult);
	CSliderCtrl m_slider;
	afx_msg void OnNMCustomdrawSlider2(NMHDR *pNMHDR, LRESULT *pResult);
	CSliderCtrl m_slider2;
	afx_msg void OnBnClickedCheck5();
	CButton m_check;
	afx_msg void OnBnClickedButton7();
	afx_msg void OnBnClickedButton8();
	afx_msg void OnBnClickedButton9();
};
