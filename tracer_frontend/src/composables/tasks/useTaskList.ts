import { ref, watch } from "vue";
import { useTaskStore } from "@/stores/task";

export const useTaskList = () => {
    const inputTask = ref("");
    const disabledInput = ref(true);
    const errorField =ref("");
    const taskStore = useTaskStore();
    function onChangeTask(value: string) {
        inputTask.value = value;
    }
    watch(inputTask, (value) => {
        if (value != "") {
            disabledInput.value = false;
            return;
        }
        disabledInput.value = true;
    });
    function removeATask(id: number) {
    }
   async function addItem(){
        if(inputTask.value==""){
            errorField.value = "Task field is required";
            return;
        }        
        disabledInput.value=true;
        await taskStore.addItem(inputTask.value);
        inputTask.value="";
        disabledInput.value=false;
    }
    return {
        inputTask, disabledInput,addItem,
        createLoading:taskStore.createLoading,
        errorField,
        removeATask, onChangeTask,
    }
}