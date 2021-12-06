<template>
  <showcase v-bind="showCaseData" />
</template>

<script>
import Showcase from '@/components/Showcase'

export default {
  name: 'ReturnList',
  components: {
    Showcase
  },
  data: () => {
    return {
      showCaseData: {
        title: 'Список возвратов',
        linkToCreate: '/returns/create',
        createCaption: 'Создать возврат',
        tableHeaders: [
          'Номер ТТН заказа',
          'Номер ТТН возврата',
          'Дата возврата',
          'Номер акта возврата',
          'Принято'
        ],
        tableData: [
          {
            ttnOrder: '29873/НУ1',
            ttnReturn: '29343/НУ1',
            returnDate: '21.10.2021',
            actOfReturn: '53463426',
            accept: 'Да'
          }
        ],
        sortTypes: [
          'ТТН заказа',
          'ТТН возврата',
          'Номер акта возврата'
        ]
      }
    }
  }
}
</script>
