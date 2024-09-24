import { EncryptStorage } from 'encrypt-storage';
export const encryptionStorageToken = new EncryptStorage(import.meta.env.VITE_ENCRYPTION_KEY,{
    prefix:"@token"
});