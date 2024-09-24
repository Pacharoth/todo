<template>
    <div class="absolute right-2 top-2 animate-fade space-y-2">
        <template v-if="status==AlertStatus.SUCCESS">
            <AlertSuccess @click="closeAlert" :message="message"/>
        </template>
        <template v-else-if="status==AlertStatus.FAILED">
            <AlertFailed @click="closeAlert" :mpessage="message"/>
        </template>
    </div>
</template>
<script setup lang="ts">
import AlertSuccess from './alerts/AlertSuccess.vue';
import AlertFailed from './alerts/AlertFailed.vue';
import { useAlertUpdate } from '../stores/alert';
import {AlertStatus} from '@/enums/AlertEnum';
const { status, message,setAlert }= useAlertUpdate();
function closeAlert(){
    setAlert(AlertStatus.NULLABLE,"");
}

</script>