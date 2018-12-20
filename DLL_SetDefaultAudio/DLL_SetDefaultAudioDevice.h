#pragma once

#include <comdef.h>
#include <atlstr.h>
#include <mmdeviceapi.h>
#include <mmeapi.h>
#include "PolicyConfig.h"

class SetDefaultAudioDevice
{
public:
	SetDefaultAudioDevice();	// 建構子
	void SetAsDefault(LPCWSTR device_ID);	// C#以String傳入device_ID, C以LPCWSTR接收參數
private:
	CString HResult2String(HRESULT hr);	// 將HRESULT訊息轉換成String
};
