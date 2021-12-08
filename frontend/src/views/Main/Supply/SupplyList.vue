<template>
  <showcase v-bind="showCaseData" />
</template>

<script>
import Showcase from '@/components/Showcase'

export default {
  name: 'SupplyList',
  components: {
    Showcase
  },
  data: () => {
    return {
      showCaseData: {
        title: 'Список поставок',
        linkToCreate: '/supplies/create',
        createCaption: 'Создать поставку',
        tableHeaders: [
          'Поставщик',
          'ТК',
          'Номер ТТН',
          'Номер платежного док.',
          'Стоимость поставки',
          'Дата поставки',
          'Принято',
          'Примечание'
        ],
        tableData: [
          {
            supplier: 'МеталлТрейд',
            tc: 'ПЭК',
            ttn: '29873/НУ1',
            payment_doc: '597824',
            price: '42 000',
            accept: '-',
            supplyData: '21.10.2021',
            extra: '-'
          }
        ],
        sortTypes: [
          'Поставщик',
          'ТК',
          'Номер ТТН',
          'Номер платежного док.'
        ]
      }
    }
  }
}
</script>
