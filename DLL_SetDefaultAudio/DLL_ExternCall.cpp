#ifdef DLL_SetDefaultAudioDevice_EXPORTS	// 專案名稱後面加上_EXPORTS
#define SetDefaultAudioDevice_API __declspec(dllexport)
#else
#define SetDefaultAudioDevice_API __declspec(dllimport)
#endif // DLL_SetDefaultAudioDevice_EXPORTS

#include "DLL_SetDefaultAudioDevice.h"

SetDefaultAudioDevice SDAD;

extern "C" SetDefaultAudioDevice_API void SetAsDefault(LPCWSTR device_ID) {
	return SDAD.SetAsDefault(device_ID);
}