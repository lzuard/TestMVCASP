<template>
  <showcase v-bind="showCaseData" />
</template>

<script>
import Showcase from '@/components/Showcase'
import { useToast } from 'vue-toastification'
import { PACKAGE_TYPES } from '@/services/dictionaries'

export default {
  name: 'ProductList',
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
        title: 'Список товаров',
        linkToCreate: '/products/create',
        createCaption: 'Создать товар',
        tableHeaders: [
          '№',
          'Артикул',
          'Производитель',
          'Наименование',
          'Категория',
          'Упаковка',
          'Кол-во в упаковке',
          'Кол-во на складе',
          'Цена',
          'Минимальный заказ',
          'Вес',
          'Высота',
          'Ширина',
          'Длина',
          'Описание',
          'Уценен',
          'Причина'
        ],
        tableData: [],
        sortTypes: []
      }
    }
  },
  created () {
    this.$api.product.getProducts()
      .then((data) => {
        this.handlingProducts(data)
        this.showCaseData.tableData = data
      })
      .catch(() => {
        this.toast.error('Ошибка при загрузке продукции')
      })
  },
  methods: {
    handlingProducts (data) {
      data.forEach((item) => {
        item.packageType = PACKAGE_TYPES[item.packageType]
        item.category = item.category.name
        item.isDiscount = item.isDiscount ? 'Да' : 'Нет'
      })
    }
  }
}
</script>
