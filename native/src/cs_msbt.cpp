#include "include/cs_msbt.h"

msbt::MSBT* FromBinary(u8* src, size_t src_len) {
  return new auto{msbt::MSBT{{src, src_len}}};
}

std::vector<u8>* ToBinary(msbt::MSBT* handle) {
  return new auto{handle->ToBinary()};
}

msbt::MSBT* FromText(const char* text) {
  return new msbt::MSBT(text);
}

std::string* ToText(msbt::MSBT* handle) {
  return new auto{handle->ToText()};
}

bool Free(msbt::MSBT* handle) {
  delete handle;
  return true;
}