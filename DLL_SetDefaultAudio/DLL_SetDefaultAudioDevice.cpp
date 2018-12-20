#include "DLL_SetDefaultAudioDevice.h"

SetDefaultAudioDevice::SetDefaultAudioDevice()
{
}

void SetDefaultAudioDevice::SetAsDefault(LPCWSTR device_ID)
{
	CoInitialize(nullptr);
	IPolicyConfigVista *pPolicyConfig;
	ERole reserved = eConsole;
	HRESULT hr = CoCreateInstance(
		__uuidof(CPolicyConfigVistaClient),
		NULL,
		CLSCTX_ALL,
		__uuidof(IPolicyConfigVista),
		(LPVOID *)&pPolicyConfig
	);
	if (SUCCEEDED(hr)) {
		hr = pPolicyConfig->SetDefaultEndpoint(device_ID, reserved);
		pPolicyConfig->Release();
	}
	CoUninitialize();
}

CString SetDefaultAudioDevice::HResult2String(HRESULT hr)
{
	_com_error error(hr);
	CString cs;
	cs.Format(_T("Error!0x%08x: %s"), hr, error.ErrorMessage());
	return cs;
}
