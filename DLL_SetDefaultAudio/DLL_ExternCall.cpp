#ifdef DLL_SetDefaultAudioDevice_EXPORTS	// �M�צW�٫᭱�[�W_EXPORTS
#define SetDefaultAudioDevice_API __declspec(dllexport)
#else
#define SetDefaultAudioDevice_API __declspec(dllimport)
#endif // DLL_SetDefaultAudioDevice_EXPORTS

#include "DLL_SetDefaultAudioDevice.h"

SetDefaultAudioDevice SDAD;

extern "C" SetDefaultAudioDevice_API void SetAsDefault(LPCWSTR device_ID) {
	return SDAD.SetAsDefault(device_ID);
}