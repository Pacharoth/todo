<template>
   <div 
    
   class="fixed overflow-hidden  duration-500 bg-slate-500/50 transition-all 

   backdrop-opacity-95  w-full h-full z-40 "
         id="modal-data" >
            <div @click="click" ref="refData" class=" relative flex
            p-2 
            w-full h-full flex-grow justify-center items-center
              overflow-y-auto
              ">
              <slot></slot>
              <AlertStatusUpdate/>
            </div>
    </div>
</template>
<script setup lang="ts">
import {ref} from 'vue';
import AlertStatusUpdate from '@/components/AlertStatusUpdate.vue';

const refData = ref();
const emit= defineEmits(['clickModal'])
function click(e){
  if(e.target==refData.value){
    emit("clickModal");
  }
}
</script>