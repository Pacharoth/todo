import { createRouter, createWebHistory } from 'vue-router'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: ()=>import('../pages/TaskPage.vue'),
      children:[
        {
          path:"/:id",
          name:"taskupdate",
          component:()=>import("@/components/tasks/EditSpecificTask.vue"),
        }
      ]
    },

    {
      path:'/:pathMatch(.*)*',
      name:"404",
      component: ()=>import('../pages/404Page.vue'),
    }
  ]
})

export default router
