<template>
    <Modal @clickModal="closeModal">
        <div @click="clickInsideModal" ref="insideModal"
            class=" relative bg-gray-50 h-[500px]  max-w-screen-sm w-full rounded-xl p-2">
            <div v-if="loading" class="w-full h-full flex justify-center">
                <SkeletonLoading className="h-5 w-6 [&>*]:w-20 [&>*]:bg-gray-400" />
            </div>
            <div ref="insideContent" v-else class=" relative w-full flex flex-col p-2">
                <!-- header to close the modal and edit  -->
                <div class="flex space-x-2 items-center">
                    <IconSchedule className="w-6 p-0 h-6 text-slate-500" :strokeWidth="2" />
                    <InputTitle :inputValue @change="onTitleChange" :statusInput="statusInput" @click="onClick(true)"
                        @submit="onSubmitTitle" />
                </div>
                <template v-if="inputDate">
                    <ShowDateInEditTask :inputDate="inputDate" :statusTask="selectTask" />
                </template>
                <!-- content  -->
                <div class="flex flex-wrap justify-between">
                    <div class="flex-col flex mt-5 space-y-2 w-full sm:w-8/12">
                        <div class="flex space-x-2 ">
                            <IconBurger className="w-6 text-slate-500" :strokeWidth="2" />
                            <p class="font-semibold text-slate-600 text-xl">Description</p>
                        </div>
                        <div class="ml-8">
                            <InputDescription :inputValue="inputDescription" @click="onClickDescription(true)"
                                :statusInput="statusInputDescription" @submit="onSubmitDescription"
                                @change="onDescription" :loading="loadingDes" @close="onClickDescription(false)" />
                        </div>
                    </div>
                    <div class=" w-full relative sm:w-3/12 text-slate-700 space-y-2">
                        <h2 class="font-semibold mb-2">Priority</h2>
                        <template v-if="selectPriority == PriorityTask.LOW">
                            <button @click="onClickPriority(!statusPriority)"
                                class="w-full font-semibold flex space-x-2 items-center bg-gray-200 hover:bg-gray-300   px-4 py-2 rounded-md ">
                                <div class="p-2 bg-slate-500 rounded-sm"></div>
                                <p class="capitalize"> {{ String(priorityTask[selectPriority]).toLowerCase() }}</p>
                            </button>
                        </template>
                        <template v-else-if="selectPriority == PriorityTask.MEDIUM">
                            <button @click="onClickPriority(!statusPriority)"
                                class="w-full font-semibold flex space-x-2 items-center  bg-gray-200 hover:bg-gray-300   px-4 py-2 rounded-md">
                                <div class="p-2 bg-amber-400 rounded-sm"></div> <span class="capitalize"> {{
                                    String(priorityTask[selectPriority]).toLowerCase() }}</span>
                            </button>
                        </template>
                        <template v-else-if="selectPriority == PriorityTask.HIGH">
                            <button @click="onClickPriority(!statusPriority)"
                                class="w-full font-semibold flex space-x-2 items-center  bg-gray-200 hover:bg-gray-300   px-4 py-2 rounded-md">
                                <div class="p-2 bg-rose-400 rounded-sm"></div> <span class="capitalize"> {{
                                    String(priorityTask[selectPriority]).toLowerCase() }}</span>
                            </button>
                        </template>
                        <template v-if="statusPriority">
                            <div class="absolute animate-fade right-2 z-10">
                                <SelectPriority @click="onSubmitPriority" :loading="loadingPriority" />
                            </div>
                        </template>
                        <h2 class="font-semibold mb-2">Status</h2>
                        <template v-if="selectTask == TaskStatus.UNCOMPLETE">
                            <button @click="onClickTask(!statusTask)"
                                class="w-full font-semibold flex space-x-2 items-center bg-gray-200 hover:bg-gray-300   px-4 py-2 rounded-md ">
                                <div class="p-2 bg-slate-500 rounded-sm"></div>
                                <p class="capitalize"> {{ String(taskStatus[selectTask]).toLowerCase() }}</p>
                            </button>
                        </template>
                        <template v-else-if="selectTask == TaskStatus.COMPLETE">
                            <button @click="onClickTask(!statusTask)"
                                class="w-full font-semibold flex space-x-2 items-center  bg-gray-200 hover:bg-gray-300   px-4 py-2 rounded-md">
                                <div class="p-2 bg-lime-700 rounded-sm"></div> <span class="capitalize"> {{
                                    String(taskStatus[selectTask]).toLowerCase() }}</span>
                            </button>
                        </template>
                        <template v-if="statusTask">
                            <div class="absolute animate-fade right-2 z-10">
                                <SelectTaskStatus @click="onSubmitTask" :loading="loadingTask" />
                            </div>
                        </template>
                        <h2 class="font-semibold mb-2">Due Date</h2>

                        <button @click="onClickDate(!statusInputDate)"
                            class="w-full font-semibold flex items-center  bg-gray-200 hover:bg-gray-300   px-2 py-2 rounded-md">
                            <IconClock className="w-5 h-5 mr-2" :strokeWidth="2" />
                            <span class="">Edit Due Date</span>
                        </button>

                        <div v-if="statusInputDate" class="absolute animate-fade right-2 z-10">
                            <InputDate @submit="onSubmitDate" title="Due Date" 
                            :inputDate="inputDate"
                            :loadingSaveStatus="loadingSaveDate"
                                :loadingRemoveStatus="loadingRemoveDate" />
                        </div>
                    </div>
                </div>
                <button @click="closeModal"
                    class="absolute right-2 top-2 text-slate-700 p-2 rounded-full hover:bg-gray-300/50 focus:bg-gray-300/50 bg-gray-50">
                    <IconXMark className=" w-5 h-5" :strokeWidth="2" />
                </button>
            </div>

        </div>
    </Modal>
</template>
<script setup lang="ts">
import Modal from './modal/Modal.vue'
import { priorityTask, PriorityTask, TaskStatus, taskStatus } from '@/enums/TaskEnum';
import IconClock from '@/components/icons/IconClock.vue'
import { ref, watch, toValue, type Ref } from 'vue';
import { useRouter, useRoute } from 'vue-router';
import { useFetchApi } from '@/composables/useApi';
import SkeletonLoading from '../loading/SkeletonLoading.vue';
import SelectPriority from './selects/SelectPriority.vue';
import SelectTaskStatus from './selects/SelectTaskStatus.vue';
import IconXMark from '@/components/icons/IconXMark.vue';
import InputTitle from '@/components/tasks/inputs/InputTitle.vue';
import InputDescription from '@/components/tasks/inputs/InputDescription.vue';
import { useTaskStore } from '@/stores/task';
import IconSchedule from '../icons/IconSchedule.vue';
import IconBurger from '../icons/IconBurger.vue';
import type { TaskType } from "@/types/TaskType";
import { mappingATaskItemFromApis } from "@/utils/tasks/mapping";
import InputDate from './inputs/InputDate.vue';
import ShowDateInEditTask from './dates/ShowDateInEditTask.vue';
const insideContent = ref();
const router = useRouter();
const route = useRoute();
const inputValue: Ref<undefined | string> = ref("");
const inputDescription: Ref<undefined | string> = ref("");
const insideModal = ref();
const loadingDes = ref(false);
const statusInput = ref(false);
const inputDate = ref("");
const statusInputDate = ref(false);
const loadingSaveDate = ref(false);
const loadingRemoveDate = ref(false);
const trackingDesOldVal: Ref<undefined | string> = ref("");
const statusInputDescription = ref(false);
const selectPriority = ref();
const selectTask = ref();
const statusPriority = ref(false);
const statusTask = ref(false);
const loadingPriority = ref(false);
const loadingTask = ref(false);
const taskStore = useTaskStore();
const serializeData: Ref<undefined | TaskType> = ref();
function closeModal(e: Event) {
    router.push("/");
}

function closeValue() {
    if (inputValue.value != "") {
        onClick(false);
    }
    if (inputDescription.value != "") {
        onClickDescription(false);
    }
    onClickPriority(false);
    onClickTask(false);
    onClickDate(false);
}
function clickInsideModal(e: Event) {
    if (e.target == toValue(insideModal)) {
        closeValue();
    } else if (e.target == toValue(insideContent)) {
        closeValue();
    }
}
function onClickDate(status: boolean) {
    statusInputDate.value = status;
}
function onClickPriority(status: boolean) {
    statusPriority.value = status;
}
function onClickTask(status: boolean) {
    statusTask.value = status;
}
function onClick(status: boolean) {
    statusInput.value = status;
}
function onClickDescription(status: boolean) {
    statusInputDescription.value = status;
    if (status) {
        trackingDesOldVal.value = inputDescription.value;
    } else {
        inputDescription.value = trackingDesOldVal.value;
    }
}
function setLDStatusBDate(e?: string, status: boolean) {
    if (e) {
        loadingSaveDate.value = status;
        return
    }
    loadingRemoveDate.value = false;
}
function onSubmitDate(e?: string) {
    let timer;
    setLDStatusBDate(e, true);
    if (timer) {
        clearTimeout(timer);
    }
    timer =
        setTimeout(async () => {
            await taskStore.updateItem({ ...serializeData.value!, "dueTo": e }, false)
            setLDStatusBDate(e, false);
            inputDate.value=e;
            onClickDate(false);
        }, 500);
}
function onSubmitDescription(e?: string) {
    let timer;
    loadingDes.value = true;
    if (timer) {
        clearTimeout(timer);
    }
    timer =
        setTimeout(async () => {
            await taskStore.updateItem({ ...serializeData.value!, "description": inputDescription.value?.trim() }, false)
            trackingDesOldVal.value = inputDescription.value?.trim();
            loadingDes.value = false;
            statusInputDescription.value = false
        }, 500);
}
function onSubmitTask(e: string) {
    loadingTask.value = true;
    let timer;
    if (timer) {
        clearTimeout(timer);
    }
    timer =
        setTimeout(async () => {
            await taskStore.updateItem({ ...serializeData.value!, "taskStatus": parseInt(e) }, false)
            statusTask.value = false
            selectTask.value = e;
            onClickPriority(false);
            loadingTask.value = false;
        }, 500);
}

function onSubmitPriority(e: string) {
    loadingPriority.value = true;
    let timer;
    if (timer) {
        clearTimeout(timer);
    }
    timer =
        setTimeout(async () => {
            await taskStore.updateItem({ ...serializeData.value!, "priorityStatus": parseInt(e) })
            statusPriority.value = false
            selectPriority.value = e;
            onClickPriority(false);
            loadingPriority.value = false;
        }, 500);
}
function onSubmitTitle(e?: string) {
    let timer;
    if (timer) {
        clearTimeout(timer);
    }
    timer =
        setTimeout(() => {
            if (inputValue.value == "") return;
            let data: TaskType = { ...serializeData.value!, "title": e ? e.trim() : "" };
            taskStore.updateItem(data)
        }, 500);
}
function onTitleChange(e?: string) {
    inputValue.value = e;
}
function onDescription(e?: string) {
    inputDescription.value = e;
}
const urlTask = `${import.meta.env.VITE_BACKENDAPI_TASK}/${route.params.id}`;
const { data, loading, error } = useFetchApi(urlTask);
watch(data, (value) => {
    if (value.data) {
        inputValue.value = value.data.title;
        serializeData.value = mappingATaskItemFromApis(toValue(value.data))
        inputDescription.value = serializeData.value?.description;
        selectPriority.value = serializeData.value.priorityStatus;
        selectTask.value = serializeData.value.taskStatus;
        inputDate.value = serializeData.value?.dueTo;
    }
})
</script>