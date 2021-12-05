<template>
  <showcase v-bind="showCaseData" />
</template>

<script>
import Showcase from '@/components/Showcase'

export default {
  name: 'TTNList',
  components: {
    Showcase
  },
  data: () => {
    return {
      showCaseData: {
        title: 'Список ТТН',
        linkToCreate: '/ttn/create',
        createCaption: 'Создать ТТН',
        tableHeaders: [
          'Номер',
          'Форма',
          'Тип'
        ],
        tableData: [
          {
            id: 'СЛУ-1/19273',
            form: 'СЛУ-1',
            type: 'Поставка'
          }
        ],
        sortTypes: [
          'Номер',
          'Форма',
          'Тип'
        ]
      }
    }
  }
}
</script>
