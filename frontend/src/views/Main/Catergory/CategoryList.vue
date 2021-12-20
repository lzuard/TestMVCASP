<template>
  <showcase v-bind="showCaseData" />
</template>

<script>
import Showcase from '@/components/Showcase'
import { useToast } from 'vue-toastification'

export default {
  name: 'CategoryList',
  components: {
    Showcase
  },
  setup () {
    const toast = useToast()
    return { toast }
  },
  data: () => {
    return {
      showCaseData: {
        title: 'Список категорий',
        linkToCreate: '/category/create',
        createCaption: 'Создать категорию',
        tableHeaders: [
          '№',
          'Название категории',
          'Родительская категория'
        ],
        tableData: [],
        sortTypes: []
      }
    }
  },
  created () {
    this.$api.category.getCategory()
      .then((data) => {
        this.handlingCategory(data)
        this.showCaseData.tableData = data
      })
      .catch(() => {
        this.toast.error('Ошибка при загрузке категорий')
      })
  },
  methods: {
    handlingCategory (data) {
      data.forEach((item) => {
        item.parentCategory = item.parentCategory.name ?? '-'
      })
    }
  }
}
</script>
