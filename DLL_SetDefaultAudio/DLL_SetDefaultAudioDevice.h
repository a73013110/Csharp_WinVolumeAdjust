#pragma once

#include <comdef.h>
#include <atlstr.h>
#include <mmdeviceapi.h>
#include <mmeapi.h>
#include "PolicyConfig.h"

class SetDefaultAudioDevice
{
public:
	SetDefaultAudioDevice();	// �غc�l
	void SetAsDefault(LPCWSTR device_ID);	// C#�HString�ǤJdevice_ID, C�HLPCWSTR�����Ѽ�
private:
	CString HResult2String(HRESULT hr);	// �NHRESULT�T���ഫ��String
};
