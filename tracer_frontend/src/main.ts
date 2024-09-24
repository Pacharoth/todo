import './assets/index.css';
import { createApp } from 'vue'
import { createPinia } from 'pinia';
import ElementPlus from 'element-plus'
import 'element-plus/dist/index.css'
import App from './App.vue'
import router from './router'
import 'vue-toast-notification/dist/theme-bootstrap.css';
import ToastPlugin from 'vue-toast-notification';
const app = createApp(App)
app.use(ElementPlus);
app.use(ToastPlugin);
app.use(createPinia())
app.use(router)
app.mount('#app')
