<template>
    <div @click="click"  class="bg-gray-100 flex 
         items-center text-green-800 px-2 
           w-full
          space-x-4
         justify-between
         py-2
          z-10 
         shadow-md rounded-md cursor-pointer">
           <div class="flex items-center space-x-2">
            <IconCircleCheck className="w-5 h-5 animate-bounce" :strokeWidth="2"/>
            <p class="font-semibold">{{message}}</p>         
           </div> 
    </div>
</template>
<script setup lang="ts">
import IconCircleCheck from '../icons/IconCircleCheck.vue';
defineProps<{message?:string,}>()
const emit = defineEmits(["click"]);
function click(){
    emit("click");
}
</script>